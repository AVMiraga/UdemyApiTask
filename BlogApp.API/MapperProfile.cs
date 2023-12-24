using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;

namespace BlogApp.API
{
    public class MapperProfile : Profile
    {
        protected MapperProfile()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CreateCategoryDTO, Category>().ReverseMap()
                .ForMember(dest => dest.ImageFile, opt => opt.Ignore());
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap()
                .ForMember(dest => dest.ImageFile, opt => opt.Ignore());
        }
    }
}
