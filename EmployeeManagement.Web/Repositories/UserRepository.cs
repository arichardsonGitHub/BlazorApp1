using EmployeeManagement.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private IAndrewSandboxContext andrewSandboxContext;

    public UserRepository(IAndrewSandboxContext andrewSandboxContext)
    {
        this.andrewSandboxContext = andrewSandboxContext;
    }

    public async Task<List<User>> GetAll()
    {
        //using (HttpClient client = new HttpClient())
        //{
        //    var users = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

        //    return JsonConvert.DeserializeObject<List<User>>(users);
        //}

        //todo: make async
        var users = await Task.Run(() => andrewSandboxContext.Users);

        var list = users.ToList();

        foreach (var user in list)
        {
            user.PhotoPath = user.GenderId == 1 ? "images/female.png" : "images/male.png";
        }

        return list;
    }

    public async Task<User> GetByID(int id)
    {
        //using (HttpClient client = new HttpClient())
        //{
        //    var user = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString());

        //    return JsonConvert.DeserializeObject<User>(user);
        //}

        var user = await Task.Run(() => andrewSandboxContext.Users.Where(x => x.Id == id).FirstOrDefault());

        return user;
    }
}
