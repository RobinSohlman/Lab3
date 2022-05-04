using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class Bokning
    {

        public int ID { get; set; }
        public BostadsAnnons Bostad { get; set; }
        public Anvandare Anvandare { get; set; }
        public int AntalPersoner { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public int TotalPris { get; set; }
        public int Status { get; set; }
        internal Bokning(BostadsAnnons bostad, Anvandare anvandare, int antalPersoner, DateTime startdatum, DateTime slutdatum, int totalPris)
        {
            Bostad = bostad;
            Anvandare = anvandare;
            AntalPersoner = antalPersoner;
            StartDatum = startdatum;
            SlutDatum = slutdatum;
            TotalPris = totalPris;
        }
        public Bokning()
        {

        }
    }
}
