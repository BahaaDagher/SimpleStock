using Volo.Abp;

namespace SimpleStock.Products
{
    public class ProductNotFoundException : BusinessException
    {
        public ProductNotFoundException(int id ) : base(SimpleStockDomainErrorCodes.PRODUCT_NOT_FOUND) 
        {
            WithData("id", id); 
        }
    }
}
