using EmployeeTaskManager.Models;
using EmployeeTaskManager.Services;
using EmployeeTaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        ITaskService _taskService;
        public TasksController(ITaskService service)
        {
            _taskService = service;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllTasks()
        {
            try
            {
                var tasks = _taskService.GetTaskList();

                if (tasks == null)
                    return NotFound();

                return Ok(tasks);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetMonthlyReport()
        {
            try
            {
                var tasks = _taskService.GetMonthlyTaskList();

                if (tasks == null)
                    return NotFound();

                return Ok(tasks);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetTasksById(long id)
        {
            try
            {
                var employees = _taskService.GetTask(id);

                if (employees == null)
                    return NotFound();

                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveTask(Models.Task task)
        {
            try
            {
                var result = _taskService.SaveTask(task);

                if (result)
                    return Ok("Details saved");
                return BadRequest("failed");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult UpdateTaskStatus(long taskId, bool isCompleted)
        {
            try
            {
                var result = _taskService.UpdateTaskStatus(taskId, isCompleted);

                if (result)
                    return Ok("Details updated");
                return BadRequest("failed");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]/id")]
        public IActionResult SaveDocumentsToTask(long id, [FromBody] Documents documents)
        {
            try
            {
                var result = _taskService.SaveDocumentsToTask(id, documents);

                if (result)
                    return Ok("Details updated");
                return BadRequest("failed");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
