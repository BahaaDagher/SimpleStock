import { GetProductListDto, ProductDto, ProductsService } from '@proxy/products';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CategoriesService, CategoryDto } from '@proxy/categories';
import { ListService, LocalizationService, PagedResultDto, PermissionService } from '@abp/ng.core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CommonModule } from '@angular/common';
import { SweetAlertService } from 'src/app/services/sweet-alert.service';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.scss',
  providers: [ListService],
})
export class ListProductsComponent implements OnInit {
  canCreate: boolean;
  canEdit: boolean;
  canDelete: boolean;
  canShowDetails: boolean;
  products$: Observable<PagedResultDto<ProductDto>>;
  searchForm: FormGroup;
  categories: CategoryDto[] = [];
  currentLang : string ; 
  
  constructor(
    private productsService: ProductsService,
    private categoriesService: CategoriesService,
    private router: Router,
    private formBuilder: FormBuilder,
    public readonly list: ListService<GetProductListDto>,
    private permissionService: PermissionService,
    private sweetAlert: SweetAlertService ,
    private localizationService : LocalizationService 
  ) {
    this.buildForm();
  }

  ngOnInit(): void {
    this.currentLang = this.localizationService.currentLang;
    this.searchProducts();
    this.categoriesService.getList({ maxResultCount: 100  }).subscribe((response) => {
      this.categories = response.items;
    });

    this.canCreate = this.permissionService.getGrantedPolicy('SimpleStock.Products.CreateEdit');
    this.canEdit = this.permissionService.getGrantedPolicy('SimpleStock.Products.CreateEdit');
    this.canDelete = this.permissionService.getGrantedPolicy('SimpleStock.Products.Delete');
    this.canShowDetails = this.permissionService.getGrantedPolicy('SimpleStock.Products.Get');
  }

  addProduct(): void {
    this.router.navigateByUrl('/products/add');
  }

  buildForm() {
    this.searchForm = this.formBuilder.group({
      filter: new FormControl(''),
      categoryId: new FormControl(-1),
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
    this.router.navigateByUrl(`/products/${id}`);
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
