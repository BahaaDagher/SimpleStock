import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCategoriesComponent } from './list-categories/list-categories.component';
import { authGuard } from '@abp/ng.core';
import { AddCategoryComponent } from './add-category/add-category.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';
import { GetCategoryComponent } from './get-category/get-category.component';

const routes: Routes = [
  {
    path : "" , 
    pathMatch :'full'  , 
    component : ListCategoriesComponent,
  }, 
  {
    path : "add" , 
    pathMatch :'full'  , 
    component : AddCategoryComponent,
  },
  {
    path : "edit/:id" , 
    pathMatch :'full'  , 
    component : EditCategoryComponent,
  },
  {
    path : ":id" , 
    pathMatch :'full'  , 
    component : GetCategoryComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
