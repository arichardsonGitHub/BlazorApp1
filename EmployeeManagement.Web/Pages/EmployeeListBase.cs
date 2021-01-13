using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<User> Users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Users = await UserRepository.GetAll();
        }

        [Inject]
        public IUserRepository UserRepository { get; set; }

        public EmployeeListBase(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public EmployeeListBase()
        {
        }
    }
}
