using System;
using System.Collections.Generic;

#nullable disable

namespace EsTeam
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int ParameterId { get; set; }
        public double Mark1 { get; set; }
        public string MarkDescription { get; set; }
        public int UserId { get; set; }
        public int AssesorId { get; set; }
        public DateTime AssessmentDate { get; set; }
        public bool IsActual { get; set; }

        public virtual Parameter Parameter { get; set; }
    }
}
