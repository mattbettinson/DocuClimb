using DocuClimb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Climb
    {
        public Climb()
        {
            Grades = new List<Grade>();
            Climbers = new List<Climber>();
        }

        public int ClimbID { get; set; }

        [Required]
        public string Name { get; set; }
    
        public virtual Location Location { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<Climber> Climbers { get; set; }

        [Required]
        public ClimbingType Type { get; set; }
    }
}
