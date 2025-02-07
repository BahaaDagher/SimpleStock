import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsRoutingModule } from './products-routing.module';
import { AddProductComponent } from './add-product/add-product.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ListProductsComponent } from './list-products/list-products.component';
import { GetProductComponent } from './get-product/get-product.component';
import { EditProductComponent } from './edit-product/edit-product.component';


@NgModule({
  declarations: [
    AddProductComponent,
    ListProductsComponent,
    GetProductComponent,
    EditProductComponent,
  ],
  imports: [
    NgxDatatableModule,
    SharedModule,
    ReactiveFormsModule,
    CommonModule,
    ProductsRoutingModule
  ]
})
export class ProductsModule { }
