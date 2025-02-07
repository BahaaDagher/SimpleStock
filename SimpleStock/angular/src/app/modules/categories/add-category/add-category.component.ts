import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService } from '@proxy/categories';

@Component({
  selector: 'app-add-category',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss'],
})
export class AddCategoryComponent   {
  categoryForm: FormGroup;

  constructor(
    private categoriesService: CategoriesService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.buildForm();
  }



  buildForm() {
    this.categoryForm = this.fb.group({
      nameAr: new FormControl('', [Validators.required, Validators.maxLength(300)]),
      nameEn: new FormControl('', [Validators.required, Validators.maxLength(300)]),
      descriptionAr: new FormControl('', [Validators.required, Validators.maxLength(1000)]),
      descriptionEn: new FormControl('', [Validators.required, Validators.maxLength(1000)]),
    });
  }

  onSubmit() {
    this.categoriesService.create(this.categoryForm.value).subscribe(() => {
      this.router.navigateByUrl('/categories');
    });
  }

  back() {
    this.router.navigateByUrl('/categories');
  }
}
