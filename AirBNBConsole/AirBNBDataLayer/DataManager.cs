using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class DataManager
    {
        public Anvandare AnvandarSkapningen(string namn, string epost, string losenord)
        {
            Anvandare a = new Anvandare(namn, epost, losenord);
            return a;
        }
        public void SkapaAnnons(Anvandare anvandare, Bostad bostad, int ppn, string beskrivning, int antalRum, bool wifi, bool parkering, bool husdjur )
        {

        }
        private AirBNBDataLayer.Context.AirBNBContext airbnbcontext;
    }
}
