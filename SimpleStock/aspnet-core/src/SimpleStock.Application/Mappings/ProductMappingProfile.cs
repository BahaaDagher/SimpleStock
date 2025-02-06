using AutoMapper;
using SimpleStock.Products;
namespace SimpleStock.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public  ProductMappingProfile()
        {
            CreateMap<Product , ProductDto>();
            CreateMap<CreateUpdateProductDto , Product>();   
        }
    }
}
