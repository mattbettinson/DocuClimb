using DocuClimb.Domain;
using DocuClimb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Data.Repositories
{
    public class GradeRepository: IRepository<Grade>
    {
        public GradeRepository(DocuClimbDbContext context)
        {
            //TODO ensure argument not null
            _context = context;
        }

        public IEnumerable<Grade> FindAll()
        {
            return _context.Set<Grade>();
        }

        public Grade FindBy(int id)
        {
            return _context.Grades.SingleOrDefault(g => g.GradeID == id);
        }

        public void Create(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

        public void Update(Grade grade)
        {
            _context.Grades.Attach(grade);
            _context.Entry(grade).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Grade grade)
        {
            _context.Grades.Attach(grade);
            _context.Grades.Remove(grade);
            _context.SaveChanges();
        }

        private DocuClimbDbContext _context;
    }
}
