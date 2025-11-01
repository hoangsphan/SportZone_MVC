using AutoMapper;
using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

public class CategoryFieldProfile : Profile
{
    public CategoryFieldProfile()
    {
        CreateMap<CategoryField, CategoryFieldDto>();
    }
}