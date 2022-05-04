using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using AirBNBDataLayer.Context;
namespace AirBNBDataLayer.Internals
{
    public class BostadRepository : GenericRepository<BostadRepository> , IBostadRepository
    {
        public BostadRepository(AirBNBContext context) : base(context)
        {
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public virtual IEnumerable<Bostad> Get(
        Expression<Func<Bostad, bool>> filter = null,
        Func<IQueryable<Bostad>, IOrderedQueryable<Bostad>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<Bostad> query = context.Bostader;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual Bostad GetByID(object id)
        {
            return context.Bostader.Find(id);
        }
        public virtual void Insert(Bostad bostadsAnnons)
        {
            context.Bostader.Add(bostadsAnnons);
        }
        public virtual void Delete(object id)
        {
            Bostad entityToDelete = context.Bostader.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(Bostad entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Bostader.Attach(entityToDelete);
            }
            context.Bostader.Remove(entityToDelete);
        }
        public virtual void Update(Bostad entityToUpdate)
        {
            context.Bostader.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
