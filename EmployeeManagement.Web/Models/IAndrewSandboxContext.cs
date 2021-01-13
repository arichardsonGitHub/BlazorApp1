using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Web.Models
{
    public interface IAndrewSandboxContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<User> Users { get; set; }
    }
}