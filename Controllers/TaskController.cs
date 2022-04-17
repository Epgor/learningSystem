using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using learningSystem.Services;
using learningSystem.Models;

namespace learningSystem.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("all")]
        public ActionResult<List<TaskDto>> GetAll()
        {
            var tasks = taskService.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetById([FromRoute]int id)
        {
            var task = taskService.GetById(id);
            return Ok(task);    
        }

        [HttpPost]
        public ActionResult Post([FromBody]UpdateTaskDto task)
        {
            taskService.Create(task);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id, [FromBody]UpdateTaskDto task)
        {
            taskService.Update(id, task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            taskService.Delete(id);
            return Ok();
        }
    }


}
