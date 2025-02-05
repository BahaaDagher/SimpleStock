using SimpleStock.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SimpleStock.Data.Categories
{
    public class CategoriesDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category , int> categoriesRepository;
        public CategoriesDataSeeder(IRepository<Category, int> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;   
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (!await categoriesRepository.AnyAsync())
            {
                var categories = new List<Category>
                {
                    new Category
                    (
                      id: 1,
                      nameAR: "أطعمة ومشروبات",
                      nameEn: "Food & Drinks",
                      descriptionAr: "يشمل جميع أنواع الأطعمة والمشروبات مثل الفواكه، الخضروات، والعصائر.",
                      descriptionEn: "Includes all types of food and drinks such as fruits, vegetables, and beverages."
                    ),
                    new Category
                    (
                      id: 2,
                      nameAR: "مواد تنظيف",
                      nameEn: "Cleaning Supplies",
                      descriptionAr: "مواد التنظيف مثل الصابون، المنظفات، والمطهرات.",
                      descriptionEn: "Cleaning supplies such as soap, detergents, and disinfectants."
                    ),
                    new Category
                    (
                      id: 3,
                      nameAR: "عطور",
                      nameEn: "Perfumes",
                      descriptionAr: "تشمل جميع أنواع العطور مثل الروائح الشرقية والعصرية.",
                      descriptionEn: "Includes all types of perfumes such as oriental and modern fragrances."
                    ),
                    new Category
                    (
                      id: 4,
                      nameAR: "بلاستيك",
                      nameEn: "Plastics",
                      descriptionAr: "منتجات البلاستيك مثل الأكياس، الزجاجات، والأوعية البلاستيكية.",
                      descriptionEn: "Plastic products such as bags, bottles, and containers."
                    ),
                };
                await this.categoriesRepository.InsertManyAsync(categories);
            }
        }
    }
}
