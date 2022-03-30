using AutoMapper;
using Meblex.ModelsDTO;
using MeblexData.Models;
using MeblexData.Models.Order;
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




            CreateMap<OrderDetail, OrderListDTO>().ReverseMap();


        }
    }
}
