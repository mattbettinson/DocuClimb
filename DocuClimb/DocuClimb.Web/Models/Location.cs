using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocuClimb.Web.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string Postcode { get; set; }

        public string AdditionalInformation { get; set; }

        public List<Climb> Climbs { get; set; }
    }
}