using Volo.Abp.Application.Dtos;

namespace SimpleStock.Products
{
    public  class GetProductListDto : PagedAndSortedResultRequestDto
    {
        public string Filter {  get; set; } 
        public int? CategoryId { get; set; }
    }
}
