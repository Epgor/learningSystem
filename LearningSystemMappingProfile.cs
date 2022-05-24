using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using learningSystem.Entities;
using learningSystem.Models;

namespace RestaurantAPI
{
    public class LearningSystemMappingProfile : Profile
    {
        public LearningSystemMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(m => m.Role, c => c.MapFrom(s => s.Role.Name));

            CreateMap<learningSystem.Entities.Task, TaskDto>(); //ambiguous name ref

            CreateMap<TaskDto, learningSystem.Entities.Task>();

            CreateMap<UpdateTaskDto, learningSystem.Entities.Task>();

            CreateMap<Quiz, QuizDto>()
                .ForMember(m => m.id, c => c.MapFrom(s => s.Id))
                .ForMember(m => m.text, c => c.MapFrom(s => s.Text));

            CreateMap<Article, ArticleDto>()
                .ForMember(m => m.id, c => c.MapFrom(s => s.Id))
                .ForMember(m => m.text, c => c.MapFrom(s => s.Text));
        }
    }
}
