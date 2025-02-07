import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesRoutingModule } from './categories-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddCategoryComponent } from './add-category/add-category.component';
import { ListCategoriesComponent } from './list-categories/list-categories.component';
import { GetCategoryComponent } from './get-category/get-category.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';


@NgModule({
  declarations: [
    AddCategoryComponent ,
    ListCategoriesComponent, 
    GetCategoryComponent, 
    EditCategoryComponent
  ],
  imports: [
    NgxDatatableModule,
    SharedModule,
    ReactiveFormsModule,
    CommonModule,
    CategoriesRoutingModule
  ]
})
export class CategoriesModule { }
