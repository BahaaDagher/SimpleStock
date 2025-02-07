using Microsoft.Extensions.Caching.Distributed;
using SimpleStock.Bases;
using SimpleStock.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace SimpleStock.Lookups
{
    public class LookupsAppService : BaseApplicationService
    {
        private readonly IRepository<Category, int> categoryRepository;
        private readonly IDistributedCache<List<CategoryDto>> categoryCash;

        public LookupsAppService(IRepository<Category, int> categoryRepository, IDistributedCache<List<CategoryDto>> categoryCash)
        {
            this.categoryRepository = categoryRepository;
            this.categoryCash = categoryCash;   
        }
        public async Task<List<CategoryDto>> GetCategories()
        {
            ////return await GetAllCategoriesFromDBAsync();
            //return await categoryCash.GetOrAddAsync(
            //    $"ALL_CATEGORIES", // CASH KEY
            //    async () => await GetAllCategoriesFromDBAsync(),
            //    () => new DistributedCacheEntryOptions
            //    {
            //        AbsoluteExpiration = System.DateTimeOffset.Now.AddHours(1)
            //    }
            //);

            // redus cash 
            return await categoryCash.GetOrAddAsync(
               $"ALL_CATEGORIES", // CASH KEY
               async () => await GetAllCategoriesFromDBAsync()
           );
        }
        public async Task<List<CategoryDto>> GetAllCategoriesFromDBAsync()
        {
            var categories = await categoryRepository.GetListAsync();
            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories);
        }
    }
}
