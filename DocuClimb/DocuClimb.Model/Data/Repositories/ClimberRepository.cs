using DocuClimb.Domain;
using DocuClimb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Data.Repositories
{
    public class ClimberRepository: IRepository<Climber>
    {
        public ClimberRepository(DocuClimbDbContext context)
        {
            //TODO ensure argument not null
            _context = context;
        }

        public IEnumerable<Climber> FindAll()
        {
            return _context.Set<Climber>();
        }

        public Climber FindBy(int id)
        {
            return _context.Climbers.SingleOrDefault(c => c.ClimberID == id);
        }

        public void Create(Climber Climber)
        {
            _context.Climbers.Add(Climber);
            _context.SaveChanges();
        }

        public void Update(Climber Climber)
        {
            _context.Climbers.Attach(Climber);
            _context.Entry(Climber).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Climber Climber)
        {
            _context.Climbers.Attach(Climber);
            _context.Climbers.Remove(Climber);
            _context.SaveChanges();
        }

        private DocuClimbDbContext _context; 
    }
}
