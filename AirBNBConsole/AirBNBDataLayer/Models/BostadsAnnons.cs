using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class BostadsAnnons
    {
        public int ID { get; set; }
        public Anvandare Anvandare { get; set; }
        public Bostad Bostad { get; set; }
        public int PPN { get; set; }
        public string Beskrivning { get; set; }
        public int AntalRum { get; set; }
        public bool WIFI { get; set; }
        public bool Parkering { get; set; }
        public bool Husdjur { get; set; }
        public bool Rokning { get; set; }
        public bool Status { get; set; }

        public BostadsAnnons(Anvandare anvandare, Bostad bostad, int ppn, string beskrivning, int antalrum, bool wifi, bool parkering, bool husdjur, bool rokning, bool status)
        {
           
            Anvandare = anvandare;
            Bostad = bostad;
            PPN = ppn;
            Beskrivning = beskrivning;
            AntalRum = antalrum;
            WIFI = wifi;
            Parkering = parkering;
            Husdjur = husdjur;
            Rokning = rokning;
            Status = status;
        }
        public BostadsAnnons()
        {

        }
    }
}