using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public class BokningRepository : IBokningRepository
    {
        private AirBNBDataLayer.Context.AirBNBContext context;

        public BokningRepository(AirBNBDataLayer.Context.AirBNBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Bokning> GetBokning()
        {
            return context.Bokningar.ToList();
        }

        public Bokning GetBokningByID(int bokningid)
        {
            return context.Bokningar.Find(bokningid);
        }

        public void InsertBokning(Bokning bokning)
        {
            context.Bokningar.Add(bokning);
        }

        public void DeleteBokning(int bokningID)
        {
            Bokning bokning = context.Bokningar.Find(bokningID);
            context.Bokningar.Remove(bokning);
        }

        public void UpdateBokning(Bokning bokning)
        {
            //context.Entry(bokning).State = EntityState.Modified;
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
