using AutoMapper;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Shared.DTOs;

namespace GoodHamburger.Application.Products.Mappings;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();
    }
}