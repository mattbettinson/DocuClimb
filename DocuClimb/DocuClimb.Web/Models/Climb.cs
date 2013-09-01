using DocuClimb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocuClimb.Web.Models
{
    public class Climb
    {
        public int ClimbID { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public List<Grade> Grades { get; set; }

        public List<Climber> Climbers { get; set; }

        public ClimbingType Type { get; set; }
    }
}