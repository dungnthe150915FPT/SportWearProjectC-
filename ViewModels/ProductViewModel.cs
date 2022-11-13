using AutoMapper;
using SportWearManage.Models;

namespace SportWearManage.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        { }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime AddedDate { get; set; }
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string SourceOfSupply { get; set; } = null!;
        public int CategoryId { get; set; }
        public int? AccountId { get; set; }

        //convert từ product view model sang product
        public static Product ToProduct(ProductViewModel productViewModel)
        {
            //tạo biến config để convert, truyền vào tham số cấu hình từ class mapper vừa tạo
            var config = new MapperConfiguration(cfg =>
            {
                ViewModelMapper.CreateProductMapper(cfg);
            });
            //convert
            var mapper = config.CreateMapper();
            return mapper.Map<ProductViewModel, Product>(productViewModel);
        }
    }
}
