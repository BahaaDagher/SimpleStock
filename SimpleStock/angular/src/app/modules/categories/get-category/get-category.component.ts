import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CategoriesService } from '@proxy/categories';
import { CategoryDto } from '@proxy/categories';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-get-category',
  standalone: true,
  imports: [CommonModule ,ReactiveFormsModule],
  templateUrl: './get-category.component.html',
  styleUrls: ['./get-category.component.scss']
})
export class GetCategoryComponent implements OnInit {
  categoryForm: FormGroup;
  categoryId: number;
  category: CategoryDto;

  constructor(
    private formBuilder: FormBuilder,
    private categoriesService: CategoriesService,
    private activatedRoute: ActivatedRoute , 
    private router : Router, 
  ) {
    this.buildForm();
  }

  ngOnInit(): void {
    this.categoryId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.categoriesService.get(this.categoryId).subscribe((category) => {
      this.category = category;
      this.categoryForm.patchValue({
        id: category.id,
        nameAr: category.nameAr,
        nameEn: category.nameEn,
        descriptionAr: category.descriptionAr,
        descriptionEn: category.descriptionEn,
        creationTime : category.creationTime ,
      });
    });
  }

  buildForm() {
    this.categoryForm = this.formBuilder.group({
      id: [''],
      nameAr: [''],
      nameEn: [''],
      descriptionAr: [''],
      descriptionEn: [''],
      creationTime: [''],
    });
  }
  cancel(): void {
    this.router.navigate(['/categories']);
  }
}
