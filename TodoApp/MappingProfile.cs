using AutoMapper;
using Entities;
using Shared.Dtos.Person;
using Shared.Dtos.Task;

namespace TodoApp
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, UpdatePersonDto>().ReverseMap();
            CreateMap<Person, CreatePersonDto>().ReverseMap();
            CreateMap<Tasks, CreateTaskDto>().ReverseMap();
            CreateMap<Tasks, TaskDto>().ReverseMap();
            CreateMap<Tasks, UpdateTaskDto>().ReverseMap();
            CreateMap<TaskDto, UpdateTaskDto>().ReverseMap();

        }
    }
}
