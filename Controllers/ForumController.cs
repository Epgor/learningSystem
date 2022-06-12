using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learningSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using PortalSportowy.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using learningSystem.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PortalSportowy.Controllers
{
    [Route("api/forum")]
    [ApiController]

    public class ForumController : ControllerBase
    {

        private readonly IForumService _ForumService;
        public ForumController(IForumService ForumService)
        {
            _ForumService = ForumService;
        }
        [HttpPost]
        public ActionResult CreateForum([FromBody] CreateForumDto dto)
        {
            
            _ForumService.CreateForum(dto);

            return Ok();
        }
        [HttpGet]
        public ActionResult<List<ForumDto>> GetAll()
        {
            var ForumeDtos = _ForumService.GetAllForum();

            return Ok(ForumeDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ForumDto> Get([FromRoute] int id)
        {
            var Forum = _ForumService.GetForumById(id);
            
            return Ok(Forum);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _ForumService.DeleteForum(id);

            return NoContent();
        }
        
        [HttpPost("{forumId}/post")]
        public ActionResult CreatePost([FromRoute]int forumId, [FromBody] CreatePostDto dto)
        {

            _ForumService.CreatePost(forumId, dto);

            return Ok();
        }
        [HttpGet("{forumId}/post")]
        public ActionResult<IEnumerable<PostDto>> GetAllPosts([FromRoute]int forumId)
        {
            var PosteDtos = _ForumService.GetAllPost(forumId);

            return Ok(PosteDtos);
        }
        

        [HttpDelete("post/{id}")]
        public ActionResult DeletePost([FromRoute] int id)
        {
            var isDeleted = _ForumService.DeletePost(id);

            return NoContent();
        }


    }
}
