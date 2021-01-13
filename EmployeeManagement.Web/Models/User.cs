using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement.Web.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public int? GenderId { get; set; }
        public string PhotoPath { get; set; }

        public virtual Address Address { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
