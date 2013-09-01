using DocuClimb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocuClimb.Web.Models
{
    public class Grade
    {
        public int GradeID { get; set; }

        public GradeSystem System { get; set; }

        public string Value { get; set; }

        public List<Climb> Climbs { get; set; }
    }
}