import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListProductsComponent } from './list-products/list-products.component';
import { AddProductComponent } from './add-product/add-product.component';

const routes: Routes = [
  {
    path : "add" , 
    pathMatch : 'full' , 
    component : AddProductComponent ,
    // canActivate : [authGuard , permissionGuard] , 
    // data : {
    //   requiredPolicy : "Demo1.Products.CreateEdit"
    // }
  }, 
  {
    path : "" , 
    pathMatch : 'full' , 
    component : ListProductsComponent ,
    // canActivate : [authGuard , permissionGuard] , 
    // data : {
    //   requiredPolicy : "Demo1.Products.List"
    // }
  }, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
