using System;
using System.Collections.Generic;

#nullable disable

namespace EsTeam
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
        public virtual Status Status { get; set; }
    }
}
