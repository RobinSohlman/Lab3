using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class Bokning
    {
        public int KundID { get; set; }
        public int ID{ get; set; }
        public int AntalPersoner { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public int TotalPris { get; set; }
        public bool Status { get; set; }
        public int BostadID { get; set; }
        public Bokning(Anvandare kund, int antalPersoner, DateTime startdatum, DateTime slutdatum, int totalPris, Bostad bostad, bool status)
        {
            BostadID = bostad.BostadID;
            KundID = kund.AnvandareID;
            AntalPersoner = antalPersoner;
            StartDatum = startdatum;
            SlutDatum = slutdatum;
            TotalPris = totalPris;
            Status = status;
        }
        public Bokning()
        {

        }
    }
}
