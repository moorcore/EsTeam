using System;
using System.Collections.Generic;

#nullable disable

namespace EsTeam
{
    public partial class Parameter
    {
        public Parameter()
        {
            Marks = new HashSet<Mark>();
            Selections = new HashSet<Selection>();
        }

        public int Id { get; set; }
        public string ParameterName { get; set; }
        public double Coefficient { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<Selection> Selections { get; set; }
    }
}
