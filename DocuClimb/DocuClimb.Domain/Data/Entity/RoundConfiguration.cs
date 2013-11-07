using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain.Data.Entity
{
    public class RoundConfiguration : EntityTypeConfiguration<Round>
    {
        public RoundConfiguration()
        {
            ToTable("Round","DocuClimb");
            HasRequired(r => r.Competition);
        }
    }
}
