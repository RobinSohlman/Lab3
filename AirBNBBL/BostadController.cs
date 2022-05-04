using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirBNBDataLayer;
using AirBNBDataLayer.Internals;

namespace AirBNBBL
{
   public class BostadController
    {
        private AirBNBDataLayer.Internals.IBostadRepository bostadRepository;
        public BostadController()
        {
           this.bostadRepository = new BostadRepository(new AirBNBDataLayer.Context.AirBNBContext());
        }
        public Bostad BostadSkapning(string adress, string stad, Anvandare anvandare)
        {
            Bostad b = new Bostad(adress, stad, anvandare);
            bostadRepository.Insert(b);
            bostadRepository.Save();
            return b;
        }
        public List<Bostad> HamtaAllaBostader()
        {
            return bostadRepository.Get().ToList();
        }
        public List<Bostad> HamtaAllaSomInloggadÄger(Anvandare inloggad)
        {
            return bostadRepository.Get(filter: bostad=> bostad.AnvandareID == inloggad.AnvandareID).ToList();
        }
        public Bostad HamtaSpecifikBostad(int id)
        {
            return bostadRepository.GetByID(id);
        }
        public bool KollaOmAnnonsÄgsAvInloggad(BostadsAnnons annons, Anvandare anvandare)
        {
            foreach(Bostad bostad in anvandare.ListaAvBostader)
            {
                if (bostad.BostadID == annons.BostadID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool KollaOmReviewÄgsAvInloggad(Review review, Anvandare anvandare)
        {
            if (anvandare.AnvandareID == review.SkribentID)
            {
                return true;
            }
            return false;
        }
        public void LaggTillAnnonsILista(BostadsAnnons annons, Bostad bostad)
        {
            bostad.ListaAvAnnons.Add(annons);
            bostadRepository.Save();
        }
        public void LaggTillReviewILista(Review review, Bostad bostad)
        {
            bostad.ListaAvReview.Add(review);
            bostadRepository.Save();
        }
        public List<BostadsAnnons> HamtaAllaAnnonserIStadenX(string x)
        {
            List<BostadsAnnons> AnnonserAttVisa = new List<BostadsAnnons>();
            List<Bostad> BostadIStadenX = bostadRepository.Get(filter: bostad => bostad.Stad== x).ToList();
            foreach(Bostad bostad1 in BostadIStadenX)
            {
                foreach (BostadsAnnons annons in bostad1.ListaAvAnnons)
                {
                    AnnonserAttVisa.Add(annons);
                }
            }
            return AnnonserAttVisa;
        }
        public bool KollaBostad(int bostadsID)
        {
            Bostad b = bostadRepository.GetByID(bostadsID);
            if (b != null)
            {
                return true;
            }
            return false;
        }
        public void UpdateraReviewListan(List<Review> reviews)
        {
            foreach (Bostad bostad in bostadRepository.Get().ToList())
            {
                foreach (Review review in reviews)
                {
                    if (bostad.BostadID == review.BostadID)
                    {
                        bostad.ListaAvReview.Add(review);
                    }
                }
            }
        }
        public void UpdateraAnnonsListan(List<BostadsAnnons>annonser)
        {
            foreach (Bostad bostad in bostadRepository.Get().ToList())
            {
                foreach (BostadsAnnons annons in annonser)
                {
                    if (bostad.BostadID == annons.BostadID)
                    {
                        bostad.ListaAvAnnons.Add(annons);
                    }
                }
            }
        }
        public void UpdateraBokningsListan(List<Bokning> bokningar)
        {
            foreach (Bostad bostad in bostadRepository.Get().ToList())
            {
                foreach (Bokning bokning in bokningar)
                {
                    if (bostad.BostadID == bokning.BostadID)
                    {
                        bostad.ListaAvBokningar.Add(bokning);
                    }
                }
            }
        }
        public List<BostadsAnnons> FiltreraBetyg(int betyg)
        {
            List<BostadsAnnons> annonserAttSkrivaUt = new List<BostadsAnnons>();

            foreach(Bostad bostad in bostadRepository.Get().ToList())
            {
                List<int> ListAvgBetyg = new List<int>();
                foreach (Review review in bostad.ListaAvReview)
                {
                    ListAvgBetyg.Add(review.Betyg);
                }
                if(ListAvgBetyg.Count > 0 && ListAvgBetyg.Average() >= betyg)
                {
                    foreach (BostadsAnnons annons in bostad.ListaAvAnnons)
                    {
                        annonserAttSkrivaUt.Add(annons);
                    }
                }
            }
            return annonserAttSkrivaUt;
        }
    }
}
