using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public class BostadsAnnonsRepository : IBostadsAnnonsRepository
    {
        private AirBNBDataLayer.Context.AirBNBContext context;

        public BostadsAnnonsRepository(AirBNBDataLayer.Context.AirBNBContext context)
        {
            this.context = context;
        }

        public IEnumerable<BostadsAnnons> GetBostadsAnnons()
        {
            return context.BostadsAnnonser.ToList();
        }

        public BostadsAnnons GetBostadsAnnonsByID(int bostadsAnnonsID)
        {
            return context.BostadsAnnonser.Find(bostadsAnnonsID);
        }

        public void InsertBostadsAnnons(BostadsAnnons bostadsAnnons)
        {
            context.BostadsAnnonser.Add(bostadsAnnons);
        }

        public void DeleteBostadsAnnons(int bostadsAnnonsID)
        {
            BostadsAnnons bostadsAnnons = context.BostadsAnnonser.Find(bostadsAnnonsID);
            context.BostadsAnnonser.Remove(bostadsAnnons);
        }

        public void UpdateBostadsAnnons(BostadsAnnons bostadsAnnons)
        {
            //context.Entry(bostadsAnnons).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
