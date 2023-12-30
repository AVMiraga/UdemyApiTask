using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;

namespace BlogApp.API
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<CreateCategoryDTO, Category>();
			CreateMap<CreateCategoryDTO, Category>().ReverseMap();
			CreateMap<UpdateCategoryDTO, Category>();
			CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
			CreateMap<GetCategoryDTO, Category>()
				.ForMember(gc => gc.ChildCategories, opt => opt.MapFrom(c => c.ChildCategories));
			CreateMap<GetCategoryDTO, Category>().ReverseMap()
                .ForMember(gc => gc.ChildCategories, opt => opt.MapFrom(c => c.ChildCategories));
        }
	}
}