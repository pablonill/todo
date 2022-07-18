using AutoMapper;
using Data;
using Repository.Interfaces;
using Service.Common;
using Service.DTO;
using Service.Interfaces;

namespace Service
{
    public class TodoService : ITodoService
    {
        private readonly IGenericRepository<Todo> _todoRepository;
        private readonly IMapper _mapper;
        public TodoService(IGenericRepository<Todo> todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }
        public ResponseModel<TodoDTO> AddTodo(TodoDTO todo)
        {
            try
            {
                var newTodo = _mapper.Map<Todo>(todo);

                if (newTodo != null)
                {
                    _todoRepository.Add(newTodo);

                    return new ResponseModel<TodoDTO>();
                }

                return new ResponseModel<TodoDTO>()
                {
                    Message = "Automapper null exception",
                    Error = true
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public ResponseModel<TodoDTO> DeleteTodo(int id)
        {
            try
            {
                _todoRepository.DeleteById(id);

                return new ResponseModel<TodoDTO>();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseModel<TodoDTO> GetTodoById(int id)
        {
            try
            {
                var todo = _todoRepository.FindById(id);

                if (todo == null) return new ResponseModel<TodoDTO>() { Error = true, Message = "Todo not found" };

                var todoDTO = _mapper.Map<TodoDTO>(todo);

                return new ResponseModel<TodoDTO>() { Data = todoDTO };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ResponseModel<List<TodoDTO>>> GetTodosAsync(bool showDeleted = false)
        {
            try
            {
                var todos = await (showDeleted ? _todoRepository.FindAllAsync() : _todoRepository.FindAllAsync(x => !x.Deleted));

                return new ResponseModel<List<TodoDTO>>()
                {
                    Data = _mapper.Map<List<Todo>, List<TodoDTO>>(todos.ToList())
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ResponseModel<TodoDTO> SetCompleted(int id)
        {
            try
            {
                var todoToUpdate = _todoRepository.FindById(id);

                if (todoToUpdate == null) return new ResponseModel<TodoDTO>() { Error = true, Message = "Todo not found" };

                todoToUpdate.CompletedDate = DateTime.Now;

                _todoRepository.Update(todoToUpdate);

                return new ResponseModel<TodoDTO>() { Data = _mapper.Map<TodoDTO>(todoToUpdate) };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseModel<TodoDTO> SetDeleted(int id)
        {
            try
            {
                var todoToUpdate = _todoRepository.FindById(id);

                if (todoToUpdate == null) return new ResponseModel<TodoDTO>() { Error = true, Message = "Todo not found" };

                todoToUpdate.Deleted = true;

                _todoRepository.Update(todoToUpdate);

                return new ResponseModel<TodoDTO>() { Data = _mapper.Map<TodoDTO>(todoToUpdate) };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
