using DocuClimb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Grade
    {
        private Grade() { }

        public Grade(string value)
        {
            Value = value;
            Climbs = new List<Climb>();
        }

        public int GradeID { get; set; }
   
        [Required]
        public GradeSystem System { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual ICollection<Climb> Climbs { get; set; }

    }
}
