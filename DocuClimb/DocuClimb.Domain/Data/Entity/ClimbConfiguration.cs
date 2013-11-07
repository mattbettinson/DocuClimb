using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain.Data.Entity
{
    public class ClimbConfiguration: EntityTypeConfiguration<Climb>
    {
        public ClimbConfiguration()
        {
            ToTable("Climb", "DocuClimb");
        }
    }
}
