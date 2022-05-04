using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class BostadsAnnons
    {
        public int BostadsAnnonsID { get; set; }
        public int PPN { get; set; }
        public string Beskrivning { get; set; }
        public int AntalRum { get; set; }
        public bool WIFI { get; set; }
        public bool Parkering { get; set; }
        public bool Husdjur { get; set; }
        public bool Rokning { get; set; }
        public bool Status { get; set; }
        public int BostadID { get; set; }
        public string BildURL { get; set; }

        public BostadsAnnons(int ppn, string beskrivning, int antalrum, bool wifi, bool parkering, bool husdjur, bool rokning, bool status, Bostad bostad, string bildurl)
        {
            BostadID = bostad.BostadID;
            PPN = ppn;
            Beskrivning = beskrivning;
            AntalRum = antalrum;
            WIFI = wifi;
            Parkering = parkering;
            Husdjur = husdjur;
            Rokning = rokning;
            Status = status;
            BildURL = bildurl;
        }
        public BostadsAnnons()
        {

        }
    }
}