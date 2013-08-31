using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuClimb.Interfaces;
using DocuClimb.Domain;
using System.Data.Entity;
using DocuClimb.Utiltities;

namespace DocuClimb.Data.Repositories
{
    public class ClimbRepository: IRepository<Climb>
    {
        public ClimbRepository(DocuClimbDbContext context)
        {
            //TODO ensure argument not null
            _context = context;
        }

        public IEnumerable<Climb> FindAll()
        {
            return _context.Set<Climb>();
        }

        public Climb FindBy(int id)
        {
            return _context.Climbs.SingleOrDefault(c => c.ClimbID == id);
        }

        public void Create(Climb climb)
        {
            _context.Climbs.Add(climb);
            _context.SaveChanges();
        }

        public void Update(Climb climb)
        {
            _context.Climbs.Attach(climb);
            _context.Entry(climb).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Climb climb)
        {
            _context.Climbs.Attach(climb);
            _context.Climbs.Remove(climb);
            _context.SaveChanges();
        }

        private DocuClimbDbContext _context;        
    }
}
