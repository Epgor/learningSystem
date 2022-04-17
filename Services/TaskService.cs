using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using learningSystem.Entities;
using learningSystem.Exceptions;
using learningSystem.Models;

namespace learningSystem.Services
{
    public interface ITaskService
    {
        public void Create(UpdateTaskDto dto);
        public void Update(int id, UpdateTaskDto dto);
        public void Delete(int id);
        public TaskDto GetById(int id);
        public List<TaskDto> GetAll();
    }

    public class TaskService : ITaskService
    {
        private readonly LearningSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;


        public TaskService(LearningSystemDbContext dbContext, IMapper mapper,
            IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }
        public void Create(UpdateTaskDto dto)
        {
            var task = _mapper.Map<Entities.Task>(dto);
            //task.CreatorId = _userContextService.GetUserId;
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }
        public void Update(int id, UpdateTaskDto dto)
        {
            var task = _dbContext
                .Tasks
                .FirstOrDefault(r => r.Id == id);

            if (task is null) 
                throw new NotFoundException("Task not found");


            //auth here

            //task = _mapper.Map<Entities.Task>(dto);
            task.Name = dto.Name;
            task.Description = dto.Description;
            task.Reminder = dto.Reminder;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {


            var task = _dbContext
                .Tasks
                .FirstOrDefault(r => r.Id == id);

            if (task is null)
                throw new NotFoundException("Task not found");

            //authorize 

            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();

        }

        public TaskDto GetById(int id)
        {

            var task = _dbContext
                .Tasks
                .FirstOrDefault(r => r.Id == id);

        

            if (task is null)
                throw new NotFoundException("Task not found");

            var result = _mapper.Map<TaskDto>(task);
            return result;
        }

        public List<TaskDto> GetAll()
        {
            var baseQuery = _dbContext
                .Tasks;

            var restaurantsDtos = _mapper.Map<List<TaskDto>>(baseQuery);

            return restaurantsDtos;
        }


    }
}
