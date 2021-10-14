using System;
using System.Collections.Generic;

#nullable disable

namespace EsTeam
{
    public partial class Department
    {
        public Department()
        {
            Selections = new HashSet<Selection>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public bool ShowPreviousEvaluations { get; set; }

        public virtual ICollection<Selection> Selections { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
