using AirBNBDataLayer;
using AirBNBDataLayer.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBBL
{
    public class BokningController
    {
        private AirBNBDataLayer.Internals.IBokningRepository bokningRepository;
        public BokningController()
        {
            this.bokningRepository = new BokningRepository(new AirBNBDataLayer.Context.AirBNBContext());
        }
        public List<Bokning> HamtaAllaBokningar()
        {
            return bokningRepository.Get().ToList();
        }
        public void UpdateraStatus()
        {
            List<Bokning> boknings = bokningRepository.Get().ToList();
            foreach (Bokning bokning in boknings)
            {
                if (bokning.SlutDatum < DateTime.Today)
                {
                    bokning.Status = false;
                }
            }
            bokningRepository.Save();
        }
        public List<DateTime> HamtaAllaUpptagnaDagar(int BostadID)
        {
            List<Bokning> boknings = bokningRepository.Get().ToList();
            List<Bokning> relevantaBokningar = boknings.Where(x => x.BostadID == BostadID).ToList();
            List<DateTime> upptagnaDagar = new List<DateTime>();
            foreach (Bokning bokning in relevantaBokningar)
            {
                for (DateTime date = bokning.StartDatum; date <= bokning.SlutDatum; date = date.AddDays(1))
                    upptagnaDagar.Add(date);
            }
            return upptagnaDagar;
        }
        public Bokning SkapaBokning(BostadsAnnons bostadsannons, Anvandare anvandare, int antalPersoner, DateTime startdatum, DateTime slutdatum, Bostad bostad)
        {
            int totalPris = TaFramPris(startdatum, slutdatum, bostadsannons.PPN);
            Bokning b = new Bokning(anvandare, antalPersoner, startdatum, slutdatum, totalPris, bostad, true);
            bokningRepository.Insert(b);
            bokningRepository.Save();
            return b;
        }
        public int TaFramPris(DateTime StartDatum, DateTime SlutDatum, int ppn)
        {
            int priset;
            var antalDagar = SlutDatum - StartDatum;
            priset = Convert.ToInt32(antalDagar.TotalDays) * ppn;
            return priset;
        }
        public bool KollaStartDatum(DateTime önstatDatum)
        {
            IEnumerable<Bokning> bokningar = bokningRepository.Get();
            foreach (Bokning bokning in bokningar)
            {
                if (!(önstatDatum >= DateTime.Today && önstatDatum > bokning.SlutDatum || önstatDatum < bokning.StartDatum))
                {
                    return false;
                }
            }
            return true;
        }
        public bool KollaSlutDatum(DateTime önstatDatum, DateTime StartDatum)
        {
            IEnumerable<Bokning> bokningar = bokningRepository.Get();
            foreach (Bokning bokning in bokningar)
            {
                if (!(önstatDatum > StartDatum && (önstatDatum > bokning.SlutDatum && StartDatum > bokning.SlutDatum) || (önstatDatum < bokning.StartDatum && StartDatum < bokning.SlutDatum)))
                {
                    return false;
                }
            }
            return true;
        }
        public bool BokningsBorttagning(int bokningsID)
        {
            Bokning b = bokningRepository.GetByID(bokningsID);
            b.Status = false;
            bokningRepository.Save();
            return true;
        }
        public List<Bokning> HamtaAllaInloggadesBokningar(Anvandare inloggad)
        {
            List<Bokning> AttSkrivaUt = bokningRepository.Get(filter: bokning => bokning.KundID == inloggad.AnvandareID).ToList();
            return AttSkrivaUt;
        }
        public List<Bokning> HamtaAllaBokningarAvInloggadesAnnonser(List<Bostad> bostads)
        {
            List<Bokning> AttSkrivaUt = new List<Bokning>();
            List <Bokning> AllaBoningar = bokningRepository.Get().ToList();
            foreach(Bokning bokning in AllaBoningar)
            {
                foreach(Bostad bostad in bostads)
                {
                    if (bostad.BostadID == bokning.BostadID)
                    {
                        AttSkrivaUt.Add(bokning);
                    }
                }
            }
            return AttSkrivaUt;
        }
    }
}
