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
			CreateMap<GetCategoryDTO, Category>();
			CreateMap<GetCategoryDTO, Category>().ReverseMap();
		}
	}
}