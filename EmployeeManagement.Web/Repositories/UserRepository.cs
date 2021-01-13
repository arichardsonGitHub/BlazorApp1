using EmployeeManagement.Web.Models;
using System.Collections.Generic;
using System.Linq;
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
        var users = await Task.Run(() => andrewSandboxContext.Users);

        var list = users.ToList();

        foreach (var user in list)
        {
            //assign a default photopath if not present
            if (string.IsNullOrEmpty(user.PhotoPath))
            {
                user.PhotoPath = user.Gender.Name.ToLower() == "female" ? "images/female.png" : "images/male.png";
            }
        }

        return list;
    }

    public async Task<User> GetByID(int id)
    {
        var user = await Task.Run(() => andrewSandboxContext.Users.Where(x => x.Id == id).FirstOrDefault());

        return user;
    }
}

//using (HttpClient client = new HttpClient())
//{
//    var users = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

//    return JsonConvert.DeserializeObject<List<User>>(users);
//}

//using (HttpClient client = new HttpClient())
//{
//    var user = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString());

//    return JsonConvert.DeserializeObject<User>(user);
//}
