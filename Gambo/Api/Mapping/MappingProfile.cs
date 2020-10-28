using Api.Resources;
using AutoMapper;
using Data.Entities;
using System.Linq;

namespace Api.Mapping
{
    public class MappingProfile : Profile
    {
        private static string BaseUrl = "https://localhost:44374/img/";

        public MappingProfile()
        {
            CreateMap<Branch, BranchResource>();

            CreateMap<Category, CategoryResource>()
                .ForMember(c => c.Photo, opt => opt.MapFrom(src => BaseUrl + src.Photo));

            CreateMap<Product, ProductResource>()
                .ForMember(p => p.Photos, opt => opt.MapFrom(src => src.ProductPhotos.Select(p => BaseUrl + p.Photo).ToArray()))
                .ForMember(p => p.Unit, opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(p => p.Price, opt => opt.MapFrom(src => src.Stocks.FirstOrDefault().Price))
                .ForMember(p => p.Quantity, opt => opt.MapFrom(src => src.Stocks.FirstOrDefault().Quanity))
                .ForMember(p => p.DiscountResource, opt => opt.MapFrom(src => src.DiscountProducts.FirstOrDefault().Discount));

            CreateMap<Discount, DiscountResource>();
        }
    }
}