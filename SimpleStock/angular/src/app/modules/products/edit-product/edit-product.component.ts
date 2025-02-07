import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductsService } from '@proxy/products';
import { ProductDto, CreateUpdateProductDto } from '@proxy/products';
import { CategoryDto, CategoriesService } from '@proxy/categories';
import { CommonModule } from '@angular/common';  

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit {
  productForm: FormGroup;
  productId: number;
  product: ProductDto;
  categories: CategoryDto[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private productsService: ProductsService,
    private categoriesService: CategoriesService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.buildForm() ; 
  }
  buildForm(){
    this.productForm = this.formBuilder.group({
      nameAr: ['', Validators.required],
      nameEn: ['', Validators.required],
      descriptionAr: ['', Validators.required],
      descriptionEn: ['', Validators.required],
      categoryId: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.productId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    
    this.categoriesService.getList({ maxResultCount: 100 }).subscribe((response) => {
      this.categories = response.items;
    });

    this.loadProductDetails();
  }

  loadProductDetails(): void {
    this.productsService.getProduct(this.productId).subscribe((product) => {
      this.product = product;
      this.productForm.patchValue({
        nameAr: product.nameAr,
        nameEn: product.nameEn,
        descriptionAr: product.descriptionAr,
        descriptionEn: product.descriptionEn,
        categoryId: product.categoryId,  
      });
    });
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      const updatedProduct: CreateUpdateProductDto = {
        id : this.productId , 
        nameAr: this.productForm.value.nameAr,
        nameEn: this.productForm.value.nameEn,
        descriptionAr: this.productForm.value.descriptionAr,
        descriptionEn: this.productForm.value.descriptionEn,
        categoryId: this.productForm.value.categoryId
      };
      
      this.productsService.updateProduct(updatedProduct).subscribe(() => {
        this.router.navigate(['/products']);
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/products']);
  }
}
