using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<List<User>> GetAll();

    Task<User> GetByID(int id);
}