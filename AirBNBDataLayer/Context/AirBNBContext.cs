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
    }
}
