using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text;

namespace AirBNBDataLayer.Context
{
    public class AirBNBContext : DbContext
    { 
        public DbSet<Bostad> Bostader { get; set; }
        public DbSet<BostadsAnnons> BostadsAnnonser { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Anvandare> Anvandare { get; set; }
        public DbSet<Bokning> Bokningar { get; set; }

        public AirBNBContext () : base ("AirBNB")
        {

        }
        public void seed ()
        {
            AirBNBDataLayer.Anvandare anvandare = new Anvandare(); 
            {
                anvandare.Namn = "Sebbe";
                anvandare.Losenord = "123";
                anvandare.Epost = "hahaha";
                anvandare.ID = 1;
            }
            Anvandare.Add(anvandare);

            SaveChanges();
        }
        public void AddAnvandare(Anvandare anvandare)
        {
            Anvandare.Add(anvandare);
            SaveChanges();
        }

    }
}
