using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain.Data.Entity
{
    public class ResultConfiguration : EntityTypeConfiguration<Result>
    {
        public ResultConfiguration()
        {
            //HasKey(r => new { ClimbID = r.Climb.ID, ClimberID = r.Climber.ID, RoundID = r.Round.ID });
            ToTable("Result", "DocuClimb");
        }
    }
}
