import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListProductsComponent } from './list-products/list-products.component';
import { AddProductComponent } from './add-product/add-product.component';
import { authGuard, permissionGuard } from '@abp/ng.core';
import { EditProductComponent } from './edit-product/edit-product.component';
import { GetProductComponent } from './get-product/get-product.component';


const routes: Routes = [
  {
    path : "add" , 
    pathMatch : 'full' , 
    component : AddProductComponent ,
    canActivate : [authGuard , permissionGuard] , 
    data : {
      requiredPolicy : "SimpleStock.Products.CreateEdit"
    }
  }, 
  {
    path : "" , 
    pathMatch : 'full' , 
    component : ListProductsComponent ,
    canActivate : [authGuard , permissionGuard] , 
    data : {
      requiredPolicy : "SimpleStock.Products.List"
    }
  }, 
  {
    path: "edit/:id",  // Route for editing a product
    component: EditProductComponent,  // This is where you'll create the EditProductComponent
    canActivate: [ authGuard, permissionGuard],
    data: {
      requiredPolicy: "SimpleStock.Products.CreateEdit"
    }
  },
  {
    path: ":id",  // Route for viewing product details
    component: GetProductComponent,  // This is where you'll create the ViewProductComponent
    canActivate: [authGuard , permissionGuard],
    data: {
      requiredPolicy: "SimpleStock.Products.Get"
    }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
