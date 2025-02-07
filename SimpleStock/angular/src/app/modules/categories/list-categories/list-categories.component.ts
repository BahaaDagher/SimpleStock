import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoriesService, CategoryDto } from '@proxy/categories';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CommonModule } from '@angular/common';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { SweetAlertService } from 'src/app/services/sweet-alert.service';

@Component({
  selector: 'app-list-categories',
  standalone: true,
  imports: [NgxDatatableModule, CommonModule],
  templateUrl: './list-categories.component.html',
  styleUrls: ['./list-categories.component.scss'],
  providers: [ListService],
})
export class ListCategoriesComponent implements OnInit {
  categories$: Observable<PagedResultDto<CategoryDto>>;

  constructor(
    private categoriesService: CategoriesService,
    private router: Router,
    private sweetAlert: SweetAlertService,
    public readonly list: ListService<CategoryDto>
  ) {}

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories() {
    this.categories$ = this.categoriesService.getList({ maxResultCount: 100 });
  }

  addCategory() {
    this.router.navigateByUrl('/categories/add');
  }

  viewCategoryDetails(id: number) {
    this.router.navigateByUrl(`/categories/${id}`);
  }

  editCategory(id: number) {
    this.router.navigateByUrl(`/categories/edit/${id}`);
  }
  addProduct() {
    this.router.navigateByUrl(`/categories/add`);
  }

  deleteCategory(id: number) {
   this.sweetAlert
      .confirm('Are you sure?', 'This action cannot be undone!')
      .then((result) => {
        if (result.isConfirmed) {
          this.categoriesService.delete(id).subscribe(() => {
            this.sweetAlert.success('Product deleted successfully.');
            this.loadCategories() ; 
          });
        }
      });
  }
}
