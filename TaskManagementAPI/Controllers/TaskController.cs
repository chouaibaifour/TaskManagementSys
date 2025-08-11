using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace TaskManagementAPI.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service) => _service = service;

        [HttpPost("AddTask")]
        public async Task<IActionResult> CreateTask(CreateTaskDto dto)
        {
            var result = await _service.CreateTaskAsync(dto);
            return CreatedAtAction(nameof(GetTaskById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
        {
            var result = await _service.UpdateTaskAsync(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _service.DeleteTaskAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var result = await _service.GetTaskByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var result = await _service.GetAllTasksAsync();
            return Ok(result);
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            var success = await _service.MarkAsCompletedAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
