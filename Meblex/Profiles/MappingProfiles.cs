using AutoMapper;
using Meblex.ModelsDTO;
using Meblex.ModelsDTO.ShoppingCartDTO;
using MeblexData.Models;
using MeblexData.Models.Order;
using MeblexData.Models.ShoppingCart;
using System.Collections.Generic;

namespace Meblex.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductDetailsDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderDetailsDTO>().ReverseMap();
            CreateMap<Category, CategoryDetailsDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Statistics, StatisticsDTO>().ReverseMap();
            CreateMap<ShoppingCartItemDTO, ShoppingCartItem>().ReverseMap();




            CreateMap<OrderDetail, OrderListDTO>().ReverseMap();


        }
    }
}
