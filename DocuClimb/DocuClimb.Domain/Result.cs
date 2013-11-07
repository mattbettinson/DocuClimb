using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain
{
    public class Result: Entity
    {
        public Result(): base() { }

        public int Points { get; set; }

        public Climber Climber { get; set; }

        public Round Round { get; set; }

        public Climb Climb { get; set; }
    }
}
