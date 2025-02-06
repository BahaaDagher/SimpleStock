import { GetProductListDto, ProductDto, ProductsService } from '@proxy/products';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CategoriesService, CategoryDto } from '@proxy/categories';
import { ListService, PagedResultDto, PermissionService } from '@abp/ng.core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CommonModule } from '@angular/common';
import { SweetAlertService } from 'src/app/services/sweet-alert.service';

@Component({
  selector: 'app-list-products',
  standalone: true,
  imports: [ReactiveFormsModule, NgxDatatableModule, CommonModule],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.scss',
  providers: [ListService],
})
export class ListProductsComponent implements OnInit {
  canCreate: boolean;
  products$: Observable<PagedResultDto<ProductDto>>;
  searchForm: FormGroup;
  categories: CategoryDto[] = [];

  constructor(
    private productsService: ProductsService,
    private categoriesService: CategoriesService,
    private router: Router,
    private formBuilder: FormBuilder,
    public readonly list: ListService<GetProductListDto>,
    private permissionService: PermissionService,
    private sweetAlert: SweetAlertService
  ) {
    this.buildForm();
  }

  ngOnInit(): void {
    this.searchProducts();
    this.categoriesService.getList({ maxResultCount: 100 }).subscribe((response) => {
      this.categories = response.items;
    });

    this.canCreate = this.permissionService.getGrantedPolicy('Demo1.Products.CreateEdit');
  }

  addProduct(): void {
    this.router.navigateByUrl('/products/add');
  }

  buildForm() {
    this.searchForm = this.formBuilder.group({
      filter: new FormControl(''),
      categoryId: new FormControl(null),
      maxResultCount: new FormControl(100),
    });
  }

  searchProducts() {
    const productStreamCreator = (query) =>
      this.productsService.getList({ ...query, ...this.searchForm.value });
    this.products$ = this.list.hookToQuery(productStreamCreator);
  }

  editProduct(id: number) {
    this.router.navigateByUrl(`/products/edit/${id}`);
  }

  viewProductDetails(id: number) {
    this.router.navigateByUrl(`/products/details/${id}`);
  }

  deleteProduct(id: number) {
    this.sweetAlert
      .confirm('Are you sure?', 'This action cannot be undone!')
      .then((result) => {
        if (result.isConfirmed) {
          this.productsService.deleteProduct(id).subscribe(() => {
            this.sweetAlert.success('Product deleted successfully.');
            this.searchProducts();
          });
        }
      });
  }
}
