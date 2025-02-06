
using SimpleStock.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace SimpleStock.Products
{
    public class ProductsAppService : BaseApplicationService , IProductsAppService
    {
        #region fields
        private readonly IRepository<Product, int> productRepository;
        #endregion

        #region ctors 
        public ProductsAppService (IRepository<Product, int> productRepository)
        {
            this.productRepository = productRepository;
        }
        #endregion

        #region ProductAppService
        //[Authorize(Demo1Permissions.CreateEditProductPermission)] 
        public async Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input)
        {
            
            var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(input); 
            var inserted = await productRepository.InsertAsync(product , autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(inserted); 
        }
        //[Authorize(Demo1Permissions.DeleteProductPermission)]
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await productRepository.GetAsync(id);
            if (product != null )
            {
                await productRepository.DeleteAsync(product);
                return true; 
            }
            return false; 
        }
        //[Authorize(Demo1Permissions.ListProductPermission)]
        public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Product.Id);
            }

            var query = productRepository
                        .WithDetailsAsync(p => p.Category)
                        .Result
                        .AsQueryable()
                        .WhereIf(
                            !input.Filter.IsNullOrWhiteSpace(),
                            p => p.NameAr.Contains(input.Filter) ||
                                 p.NameEn.Contains(input.Filter)
                        )
                        .WhereIf(
                            input.CategoryId.HasValue && input.CategoryId != -1 , 
                            p=>p.CategoryId == input.CategoryId
                        ); 

            var totalCount = await query.CountAsync();

            var products = await query
                            .OrderBy(input.Sorting)
                            .Skip(input.SkipCount)
                            .Take(input.MaxResultCount)
                            .ToListAsync();

            return new PagedResultDto<ProductDto>(
                totalCount,
                ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
            );
        }
        //[Authorize(Demo1Permissions.GetProductPermission)]
        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await productRepository
                                .WithDetailsAsync(p=>p.Category)
                                .Result
                                .FirstOrDefaultAsync(p=>p.Id==id);
            if (product== null)
            {
                throw new ProductNotFoundException(id); 
            }
            return  ObjectMapper.Map<Product, ProductDto>(product);
            
        }
        //[Authorize(Demo1Permissions.CreateEditProductPermission)]
        public async Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto input  )
        {
            var exisiting  = await productRepository.GetAsync(input.Id); // product 
            if (exisiting == null )
            {
                throw new ProductNotFoundException(input.Id); 
            }
            var mapped = ObjectMapper.Map<CreateUpdateProductDto, Product>(input, exisiting); // product 
            var updated = await productRepository.UpdateAsync(mapped, autoSave: true); // product
            return ObjectMapper.Map<Product, ProductDto>(updated); 

        } 
        #endregion
    }
}
