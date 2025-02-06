using AutoMapper;
using SimpleStock.Categories;

namespace SimpleStock.Mappings
{
    public  class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile() {
            // get
            CreateMap<Category, CategoryDto>();
            // create and update
            CreateMap<CreateUpdateCategoryDto, Category>(); 
        }
    }
}
