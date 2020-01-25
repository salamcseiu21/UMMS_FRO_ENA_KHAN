using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using UniversityManagementSystem.DAL.Contracts;
using UniversityManagementSystem.DatabaseContext.DatabaseContexts;

namespace UniversityManagementSystem.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ProjectDbContext db = new ProjectDbContext();
        public DbSet<T> Table
        {
            get { return db.Set<T>(); }
        }

        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }

        public virtual T GetById(long? id)
        {
            return Table.Find(id);

        }
        public virtual ICollection<T> GetAll()
        {
            return Table
                .ToList();
        }
        public virtual bool Remove(T entity)
        {


            db.Entry(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;

        }



        public virtual bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
