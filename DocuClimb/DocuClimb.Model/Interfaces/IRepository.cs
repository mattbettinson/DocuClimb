using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        T FindBy(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
