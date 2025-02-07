import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CategoriesService, CreateUpdateCategoryDto } from '@proxy/categories';
import { CategoryDto } from '@proxy/categories';
import { CommonModule } from '@angular/common';  

@Component({
  selector: 'app-edit-category',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],  
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss']
})
export class EditCategoryComponent implements OnInit {
  categoryForm: FormGroup;
  categoryId: number;
  category: CategoryDto;

  constructor(
    private formBuilder: FormBuilder,
    private categoriesService: CategoriesService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.buildForm();
  }

  buildForm() {
    this.categoryForm = this.formBuilder.group({
      nameAr: ['', Validators.required],
      nameEn: ['', Validators.required],
      descriptionAr: ['', Validators.required],
      descriptionEn: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.categoryId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.loadCategoryDetails();
  }

  loadCategoryDetails(): void {
    this.categoriesService.get(this.categoryId).subscribe((category) => {
      this.category = category;
      this.categoryForm.patchValue({
        nameAr: category.nameAr,
        nameEn: category.nameEn,
        descriptionAr: category.descriptionAr,
        descriptionEn: category.descriptionEn,
      });
    });
  }

  onSubmit(): void {
    if (this.categoryForm.valid) {
      const updatedCategory: CreateUpdateCategoryDto = {
        nameAr: this.categoryForm.value.nameAr,
        nameEn: this.categoryForm.value.nameEn,
        descriptionAr: this.categoryForm.value.descriptionAr,
        descriptionEn: this.categoryForm.value.descriptionEn,
      };
  
      // Pass both the categoryId and updatedCategory to the update method
      this.categoriesService.update(this.categoryId, updatedCategory).subscribe(() => {
        this.router.navigate(['/categories']);
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/categories']);
  }
}
