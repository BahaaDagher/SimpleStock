﻿using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SimpleStock.Products
{
    public interface IProductsAppService 
    {
        Task<ProductDto> CreateProductAsync(CreateUpdateProductDto input); 
        Task<ProductDto> UpdateProductAsync(CreateUpdateProductDto input);
        Task<ProductDto> GetProductAsync(int id);
        Task<bool> DeleteProductAsync(int id);
        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input); 
    }
}
