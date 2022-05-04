using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirBNBDataLayer;
using AirBNBDataLayer.Internals;

namespace AirBNBBL
{
    public class AnvandarController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public Anvandare Inloggad
        {
            get; private set;
        }
        public void AnvandarSkapning(string namn, string epost, string losenord)
        {
            Anvandare a = new Anvandare(losenord, namn, epost);
            unitOfWork.AnvandareRepository.Insert(a);
            unitOfWork.AnvandareRepository.Save();
        }
        public bool LoggaInAnvandare(string email, string losenord)
        {
            IEnumerable<Anvandare> anvandarna = unitOfWork.AnvandareRepository.Get();
            foreach (Anvandare anvandaren in anvandarna)
            {
                if (anvandaren.Epost == email && anvandaren.Losenord == losenord)
                {
                    Inloggad = anvandaren;
                    return true;
                }
            }
            return false;
        }
        public Anvandare HamtaInloggad(int ID)
        {
            Anvandare a = unitOfWork.AnvandareRepository.GetByID(ID);
            return a;
        }
        public void UpdateraBostadIListan(List<Bostad> bostader)
        {
            foreach (Anvandare anvandare in unitOfWork.AnvandareRepository.Get().ToList())
            {
                foreach (Bostad bostad in bostader)
                {
                    if (bostad.AnvandareID == anvandare.AnvandareID)
                    {
                        anvandare.ListaAvBostader.Add(bostad);
                    }  
                }                  
            }            
        }
        public void LaggTillNyBostadIListan(Bostad bostad, Anvandare anvandare)
        {
            anvandare.ListaAvBostader.Add(bostad);
        }
        public bool kollaEpost(string email)
        {
            IEnumerable<Anvandare> anvandarna = unitOfWork.AnvandareRepository.Get();
            foreach (Anvandare anvandaren in anvandarna)
            {
                if (anvandaren.Epost == email)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
