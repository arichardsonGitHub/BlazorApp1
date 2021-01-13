using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    public async Task<List<User>> GetAll()
    {
        using (HttpClient client = new HttpClient())
        {
            var users = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            return JsonConvert.DeserializeObject<List<User>>(users);
        }
    }

    public async Task<User> GetByID(int id)
    {
        using (HttpClient client = new HttpClient())
        {
            var user = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users/" + id.ToString());

            return JsonConvert.DeserializeObject<User>(user);
        }
    }
}
