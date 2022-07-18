using Service.Common;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITodoService
    {
        Task<ResponseModel<List<TodoDTO>>> GetTodosAsync(bool showDeleted = false);
        ResponseModel<TodoDTO> AddTodo(TodoDTO todo);
        ResponseModel<TodoDTO> SetCompleted(int id);
        ResponseModel<TodoDTO> DeleteTodo(int id);
        ResponseModel<TodoDTO> GetTodoById(int id);
        ResponseModel<TodoDTO> SetDeleted(int id);
    }
}
