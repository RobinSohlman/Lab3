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
        public BostadsAnnons AnnonsSkapning(int ppn, string beskrivning, int antalrum, bool wifi, bool parkering, bool husdjur, bool rokning, bool status , Bostad bostad, string bildurl)
        {
            BostadsAnnons c = new BostadsAnnons(ppn, beskrivning, antalrum, wifi, parkering, husdjur, rokning, status, bostad, bildurl);
            bostadsannonsRepository.Insert(c);
            bostadsannonsRepository.Save();
            return c;
        }
        public List<BostadsAnnons> HamtaAllaAnnonser()
        {
            return bostadsannonsRepository.Get().ToList();
        }
        public List<BostadsAnnons> HamtaAllaAnnonserForInloggad(Anvandare a)
        {
            List<BostadsAnnons> AnnonserAttVisa = new List<BostadsAnnons>();
            foreach (Bostad bostad in a.ListaAvBostader)
            {
                foreach (BostadsAnnons annons in bostad.ListaAvAnnons)
                {
                    AnnonserAttVisa.Add(annons);
                }
            }
            return AnnonserAttVisa;
        }
        public IEnumerable<BostadsAnnons> HamtaAllaAnnonserDarWifiFinns(bool x)
        {
            return bostadsannonsRepository.Get(filter: annons => annons.WIFI == x);
        }
        public IEnumerable<BostadsAnnons> HamtaAllaAnnonserDarParkeringFinns(bool x)
        {
            return bostadsannonsRepository.Get(filter: annons => annons.Parkering == x);
        }
        public IEnumerable<BostadsAnnons> HamtaAllaAnnonserDarManFarHaDjur(bool x)
        {
            return bostadsannonsRepository.Get(filter: annons => annons.Husdjur == x);
        }
        public IEnumerable<BostadsAnnons> HamtaAllaAnnonserDarManFarRoka(bool x)
        {
            return bostadsannonsRepository.Get(filter: annons => annons.Rokning == x);
        }
        public IEnumerable<BostadsAnnons> HamtaAllaAnnonserMedXRum(int x)
        {
            return bostadsannonsRepository.Get(filter: annons => annons.AntalRum >= x);
        }
        public IEnumerable<BostadsAnnons> HamtaAllaAnnonserUnderXPris(int x)
        {
            return bostadsannonsRepository.Get(filter: annons => annons.PPN >= x);
        }
        public bool AnnonsBorttagning(int annonsID)
        {
            BostadsAnnons b = bostadsannonsRepository.GetByID(annonsID);
            b.Status = false;
            bostadsannonsRepository.Update(b);
            bostadsannonsRepository.Save();
            return true;
        }
        public BostadsAnnons HamtaAnnons(int annonsID)
        {
            return bostadsannonsRepository.GetByID(annonsID);
        }
        public bool KollaAnnons(int annonsID)
        {
            BostadsAnnons b = bostadsannonsRepository.GetByID(annonsID);
            if (b != null)
            {
                return true;
            }
            return false;
        }
        public List<BostadsAnnons> ÄndraListan(List<BostadsAnnons> LäggTill, List<BostadsAnnons> bostadsAnnonsernaSomSkaVisas)
        {
            List<BostadsAnnons> TaBort = new List<BostadsAnnons>();
            if (bostadsAnnonsernaSomSkaVisas.Count == 0)
            {
                bostadsAnnonsernaSomSkaVisas = LäggTill;
            }
            else
            {
                foreach (BostadsAnnons bostadsAnnons in bostadsAnnonsernaSomSkaVisas)
                {
                    if (bostadsAnnonsernaSomSkaVisas.Count > 0 && !LäggTill.Contains(bostadsAnnons))
                    {
                        TaBort.Add(bostadsAnnons);
                    }
                }
                foreach (BostadsAnnons bostadsAnnons in TaBort)
                {

                    bostadsAnnonsernaSomSkaVisas.Remove(bostadsAnnons);
                }
            }
            return bostadsAnnonsernaSomSkaVisas;
        }
    }
}
