using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using learningSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalSportowy.Models;
using System.Linq.Expressions;
using learningSystem.Exceptions;

namespace learningSystem.Services
{
    public interface IForumService
    {
        public ForumDto GetForumById(int Id);
        public List<ForumDto> GetAllForum();
        public void CreateForum(CreateForumDto dto);
        public bool DeleteForum(int id);

        public PostDto GetPostById(int Id);
        public List<PostDto> GetAllPost(int forumId);
        public void CreatePost(int forumId, CreatePostDto dto);
        public bool DeletePost(int id);

    }

    public class ForumService : IForumService
    {
        private readonly LearningSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public ForumService(LearningSystemDbContext dBContext, IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public ForumDto GetForumById(int id)
        {
            
            var Forum = _dbContext
            .Forums
            .FirstOrDefault(r => r.Id == id);

            if (Forum is null) throw new NotFoundException("null forum");

            ForumDto dto = new ForumDto()
            {
                id = Forum.Id,
                text = Forum.Text,
                title = Forum.Title,
                author = Forum.Author,
                data = Forum.Data.ToString("dd/MM/yyyy HH:mm")
            };
            
            return dto;
            
            
        }

        public List<ForumDto> GetAllForum()
        {
            var baseQuery = _dbContext
            .Forums
            .ToList();

            List<ForumDto> list = new List<ForumDto>();

            foreach(var forum in baseQuery)
            {
                ForumDto dto = new ForumDto()
                {
                    id = forum.Id,
                    text = forum.Text,
                    title = forum.Title,
                    author = forum.Author,
                    data = forum.Data.ToString("dd/MM/yyyy HH:mm")
                };
                list.Add(dto);
            }

            list.Reverse();

            return list;
        }

        public void CreateForum(CreateForumDto dto)
        {

            var newForum = new Forum()
            {
                Text = dto.text,
                Title = dto.title,
                Author = dto.author,

            };

            _dbContext.Forums.Add(newForum);
            _dbContext.SaveChanges();


        }

        public bool DeleteForum(int id)
        {
            var Forum = _dbContext
            .Forums
            .FirstOrDefault(r => r.Id == id);

            if (Forum is null) return false;

            _dbContext.Forums.Remove(Forum);
            _dbContext.SaveChanges();

            return true;
        }


    
        public PostDto GetPostById(int id)
        {

            var Post = _dbContext
            .Posts
            .FirstOrDefault(r => r.Id == id);

            if (Post is null) throw new NotFoundException("null forum");

            PostDto dto = new PostDto()
            {
                id = Post.Id,
                text = Post.Text,
                author = Post.Author,
                data = Post.Data.ToString("dd/MM/yyyy HH:mm")
            };

            return dto;

        }

        public List<PostDto> GetAllPost(int forumId)
        {
            var baseQuery = _dbContext
            .Posts
            .Where(r => r.ForumId == forumId)
            .ToList();



            List<PostDto> list = new List<PostDto>();

            foreach (var post in baseQuery)
            {

                PostDto dto = new PostDto()
                {
                    id = post.Id,
                    text = post.Text,
                    author = post.Author,
                    data = post.Data.ToString("dd/MM/yyyy HH:mm")
                };
                list.Add(dto);
            }
            list.Reverse();
            return list;

        }

        public void CreatePost(int forumId, CreatePostDto dto)
        {

            var newPost = new Post()
            {

                Text = dto.text,
                Author = dto.author,
                ForumId = forumId

            };

            _dbContext.Posts.Add(newPost);
            _dbContext.SaveChanges();


        }

        public bool DeletePost(int id)
        {
            var Post = _dbContext
            .Posts
            .FirstOrDefault(r => r.Id == id);

            if (Post is null) return false;

            _dbContext.Posts.Remove(Post);
            _dbContext.SaveChanges();

            return true;
        }

       
    }
}