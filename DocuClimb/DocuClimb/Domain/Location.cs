using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Location
    {
        public Location() 
        {
            Climbs = new List<Climb>();
        }

        public int LocationID { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        [Required]
        public string Postcode { get; set; }

        public string AdditionalInformation { get; set; }

        public virtual ICollection<Climb> Climbs { get; set; }
    }
}
