using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public class BostadRepository : IBostadRepository
    {
        private AirBNBDataLayer.Context.AirBNBContext context;

        public BostadRepository(AirBNBDataLayer.Context.AirBNBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Bostad> GetBostad()
        {
            return context.Bostader.ToList();
        }

        public Bostad GetBostadByID(int bostadID)
        {
            return context.Bostader.Find(bostadID);
        }

        public void InsertBostad(Bostad bostad)
        {
            context.Bostader.Add(bostad);
        }

        public void DeleteBostad(int bostadID)
        {
            Bostad bostad = context.Bostader.Find(bostadID);
            context.Bostader.Remove(bostad);
        }

        public void UpdateBostad(Bostad bostad)
        {
            //context.Entry(bostad).State = EntityState.Modified;
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
