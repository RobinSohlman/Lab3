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
    public class BostadsAnnonsRepository : GenericRepository<BostadsAnnonsRepository>, IBostadsAnnonsRepository
    {
        public BostadsAnnonsRepository(AirBNBContext context) : base(context)
        {
        }
        public virtual IEnumerable<BostadsAnnons> Get(
        Expression<Func<BostadsAnnons, bool>> filter = null,
        Func<IQueryable<BostadsAnnons>, IOrderedQueryable<BostadsAnnons>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<BostadsAnnons> query = context.BostadsAnnonser;

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
        public virtual BostadsAnnons GetByID(object id)
        {
            return context.BostadsAnnonser.Find(id);
        }
        public virtual void Insert(BostadsAnnons bostadsAnnons)
        {
            context.BostadsAnnonser.Add(bostadsAnnons);
        }
        public virtual void Delete(object id)
        {
            BostadsAnnons entityToDelete = context.BostadsAnnonser.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(BostadsAnnons entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.BostadsAnnonser.Attach(entityToDelete);
            }
            context.BostadsAnnonser.Remove(entityToDelete);
        }
        public virtual void Update(BostadsAnnons entityToUpdate)
        {
            context.BostadsAnnonser.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
    

