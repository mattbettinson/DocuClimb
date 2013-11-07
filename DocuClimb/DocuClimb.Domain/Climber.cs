using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Climber: Entity
    {
        public Climber() : base() 
        {
            Entries = new Collection<Competition>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HomeTown { get; set; }

        // Move to User entity?
        public string Email { get; set; }

        public ICollection<Competition> Entries { get; set; }
    }
}
