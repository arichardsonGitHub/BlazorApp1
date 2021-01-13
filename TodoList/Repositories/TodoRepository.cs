using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class TodoRepository : ITodoRepository
{
    private readonly HttpClient httpClient;

    public TodoRepository(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }

    public async Task<List<TodoItem>> GetAll()
    {
        using (httpClient)
        {
            var todos = httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            var xxx = todos.Result;

            return JsonConvert.DeserializeObject<List<TodoItem>>(xxx);
        }
    }

    public async Task<TodoItem> GetByID(int id)
    {
        using (HttpClient client = new HttpClient())
        {
            var todo = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/" + id.ToString());

            return JsonConvert.DeserializeObject<TodoItem>(todo);
        }
    }
}