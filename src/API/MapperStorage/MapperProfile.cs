using API.Models;
using AutoMapper;
using DataLayer.Entities;

namespace API.MapperStorage
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductModel, Products>();
        }
    }
}
