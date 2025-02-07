import { CommonModule } from '@angular/common';
import { ProductsService } from './../../../proxy/products/products.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductDto } from '@proxy/products';

@Component({
  selector: 'app-get-product',
  templateUrl: './get-product.component.html',
  styleUrl: './get-product.component.scss'
})
export class GetProductComponent implements OnInit {
  productForm : FormGroup ; 
  productId : number ; 
  product : ProductDto ; 
  constructor(
    private formBuilder: FormBuilder,
    private productsService :ProductsService , 
    private activatedRoute :  ActivatedRoute , 
    private router : Router, 
  ){}
  ngOnInit(): void {
    this.productId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.productsService.getProduct(this.productId).subscribe((product)=>{
      this.product = product 
      this.productForm.patchValue({
        id : product.id , 
        nameAr: product.nameAr,
        nameEn: product.nameEn,
        descriptionAr: product.descriptionAr,
        descriptionEn: product.descriptionEn,
        categoryId: product.categoryId,
        creationTime: product.creationTime,
      });
    })
    this.buildForm();
  }
  buildForm() {
    this.productForm = this.formBuilder.group({
      id: [''], 
      nameAr: [''],
      nameEn: [''],
      descriptionAr: [''],
      descriptionEn: [''],
      categoryId: [''],
      creationTime: [''],
    })
  }

  cancel(): void {
    this.router.navigate(['/products']);
  }
  

}
