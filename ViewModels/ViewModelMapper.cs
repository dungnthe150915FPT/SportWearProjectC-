using AutoMapper;
using SportWearManage.Models;

namespace SportWearManage.ViewModels
{
    public class ViewModelMapper : Profile
    {
        //cấu hình (config cho mapper) để chuyển từ Product sang ProductViewModel hoặc ngược lại
        public static void CreateProductMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, ProductViewModel>();
            cfg.CreateMap<ProductViewModel, Product>();
        }
    }
}
