using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Climber
    {
        public Climber()
        {
            Climbs = new List<Climb>();
        }

        public int ClimberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomeTown { get; set; }

        public virtual ICollection<Climb> Climbs { get; set; }
    }
}
