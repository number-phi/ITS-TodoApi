using AutoMapper;
using TodoApi.Models;
using TodoApi.Data.Entities;

namespace TodoApi.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<TodoItem, TodoItemModel>().ReverseMap();
            CreateMap<TodoItem, TodoItemBaseModel>().ReverseMap();
        }
    }
}
