using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement.Web.Models
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
