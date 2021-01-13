using EmployeeManagement.Models;

public class User
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }

    public Address Address { get; set; }
    public Company Company { get; set; }

    public Gender Gender { get; set; }

    public string PhotoPath { get; set; } = "images/female.png";
}
