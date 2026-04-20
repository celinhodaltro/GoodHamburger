using AutoMapper;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Shared.DTOs;

namespace GoodHamburger.Application.Products.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}