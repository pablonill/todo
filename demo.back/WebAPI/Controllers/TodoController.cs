using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Common;
using Service.DTO;
using Service.Interfaces;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("{id}")]
        public IActionResult GetTodo(int id) => Ok(_todoService.GetTodoById(id));

        [HttpGet("all")]
        public async Task<IActionResult> GetTodos([FromQuery] bool showDeleted) => Ok(await _todoService.GetTodosAsync(showDeleted));

        [HttpPost]
        [ValidateModel]
        public ActionResult<TodoDTO> Create(TodoDTO todo) => Ok(_todoService.AddTodo(todo));

        [HttpPatch("setcompleted/{id}")]
        public IActionResult SetCompleted(int id) => Ok(_todoService.SetCompleted(id));

        [HttpPatch("setdeleted/{id}")]
        public IActionResult SetDeleted(int id) => Ok(_todoService.SetDeleted(id));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(_todoService.DeleteTodo(id));
    }
}
