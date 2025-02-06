import { PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService, CategoryDto } from '@proxy/categories';
import { ProductsService } from '@proxy/products';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [ ReactiveFormsModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.scss'
})
export class AddProductComponent implements OnInit{

  productForm : FormGroup ; 
  categories : CategoryDto[] = []; 
  categoryInput : PagedAndSortedResultRequestDto = {maxResultCount : 100, skipCount: 0, sorting:"" } ;
  constructor(
    private productsService : ProductsService , 
    private categoryService : CategoriesService , 
    private router : Router ,
    private fb : FormBuilder , 
  ){
    this.buildForm() ;
  }

  ngOnInit(): void {
    this.categoryService.getList(this.categoryInput).subscribe((response)=>{
      this.categories = response.items ; 
    })
  }

  buildForm() {
    this.productForm = this.fb.group({
      nameAr : new FormControl('' ,[Validators.required , Validators.maxLength(300)]) , 
      nameEn : new FormControl('' ,[Validators.required , Validators.maxLength(300)]) , 
      descriptionAr : new FormControl('' ,[Validators.required , Validators.maxLength(1000)]) , 
      descriptionEn : new FormControl('' ,[Validators.required , Validators.maxLength(1000)]) , 
      categoryId : new FormControl(null ,[Validators.required ]) , 
    })
  }

  onSubmit() {
    this.productsService.createProduct(this.productForm.value).subscribe((response)=>{
      this.router.navigateByUrl('/products')
    })
  }
  back() {
    this.router.navigateByUrl('/products') // remove any path before it
    // this.router.navigateByUrl('products') // continue with current path 

  }
}
