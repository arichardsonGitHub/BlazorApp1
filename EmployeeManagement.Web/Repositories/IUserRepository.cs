using EmployeeManagement.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();

    Task<User> GetByIDAsync(int id);
}
