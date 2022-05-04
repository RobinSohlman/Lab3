using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public class AnvandareRepository : IAnvandareRepository
    {
        private AirBNBDataLayer.Context.AirBNBContext context;

        public AnvandareRepository(AirBNBDataLayer.Context.AirBNBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Anvandare> GetAnvandare()
        {
            return context.Anvandare.ToList();
        }

        public Anvandare GetAnvandareByID(int anvandareid)
        {
            return context.Anvandare.Find(anvandareid);
        }

        public void InsertAnvandare(Anvandare student)
        {
            context.Anvandare.Add(student);
        }

        public void DeleteAnvandare(int anvandareID)
        {
            Anvandare anvandare = context.Anvandare.Find(anvandareID);
            context.Anvandare.Remove(anvandare);
        }

        public void UpdateAnvandare(Anvandare anvandare)
        {
           // context.Entry(anvandare).State = EntityState.Modified;
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
