using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain.Data.Entity
{
    public class CompetitionConfiguration: EntityTypeConfiguration<Competition>
    {
        public CompetitionConfiguration()
        {
            ToTable("Competition","DocuClimb");
        }
    }
}
