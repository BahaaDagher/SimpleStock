using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SimpleStock.Categories
{
    public interface ICategoriesAppService : ICrudAppService<CategoryDto, int, PagedAndSortedResultRequestDto, CreateUpdateCategoryDto>
    {

    }
}
