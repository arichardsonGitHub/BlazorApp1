using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITodoRepository
{
    Task<List<TodoItem>> GetAll();

    Task<TodoItem> GetByID(int id);
}