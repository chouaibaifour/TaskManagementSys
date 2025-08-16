using Domain.DTOs.Task;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace TaskManagementAPI.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service) => _service = service;

        [HttpPost("Tasks")]
        public async Task<IActionResult> CreateTask(CreateTaskDto dto)
        {
            var result = await _service.CreateTaskAsync(dto);
            return CreatedAtAction(nameof(CreateTask), new { id = result.Id }, result);
        }

        [HttpPut("Tasks")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
        {
            var result = await _service.UpdateTaskAsync(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("Tasks/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _service.DeleteTaskAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet("Tasks/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var result = await _service.GetTaskByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("Tasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var result = await _service.GetAllTasksAsync();
            return Ok(result);
        }

        [HttpPatch("Tasks/{id}/complete")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            var success = await _service.MarkAsCompletedAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
