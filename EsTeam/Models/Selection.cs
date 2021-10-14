using System;
using System.Collections.Generic;

#nullable disable

namespace EsTeam
{
    public partial class Selection
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string SelectionName { get; set; }
        public int ParameterId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Parameter Parameter { get; set; }
    }
}
