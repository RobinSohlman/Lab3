using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirBNBDataLayer;
using AirBNBDataLayer.Internals;

namespace AirBNBBL
{
    public class BostadsAnnonsController
    {
        private AirBNBDataLayer.Internals.IBostadsAnnonsRepository bostadsannonsRepository;
        public BostadsAnnonsController()
        {
            this.bostadsannonsRepository = new BostadsAnnonsRepository(new AirBNBDataLayer.Context.AirBNBContext());
        }

        public int AnnonsSkapning(Anvandare anvandare, Bostad bostad, int ppn, string beskrivning, int antalrum, bool wifi, bool parkering, bool husdjur, bool rokning, bool status)
        {
            BostadsAnnons c = new BostadsAnnons(anvandare, bostad, ppn, beskrivning, antalrum, wifi, parkering, husdjur, rokning, status);
            bostadsannonsRepository.InsertBostadsAnnons(c);
            bostadsannonsRepository.Save();
            return c.ID;
        }
        public IEnumerable<BostadsAnnons> HamtaAllaAnnonser()
        {
            return bostadsannonsRepository.GetBostadsAnnons();
        }
    }
}
