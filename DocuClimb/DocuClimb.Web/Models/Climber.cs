using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocuClimb.Web.Models
{
    public class Climber
    {
        public int ClimberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomeTown { get; set; }

        public List<Climb> Climbs { get; set; }
    }
}