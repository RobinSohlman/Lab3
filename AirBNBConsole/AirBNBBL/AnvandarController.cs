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
        private AirBNBDataLayer.Internals.IAnvandareRepository anvandareRepository;
        public Anvandare Inloggad
        {
            get; private set;
        }


        public AnvandarController()
        {
            this.anvandareRepository = new AnvandareRepository(new AirBNBDataLayer.Context.AirBNBContext());
        }

        public void AnvandarSkapning(string namn, string epost, string losenord)
        {
            Anvandare a = new Anvandare(losenord, namn, epost);
            anvandareRepository.InsertAnvandare(a);
            anvandareRepository.Save();
        }
        public bool LoggaInAnvandare(string email, string losenord)
        {
            IEnumerable<Anvandare> anvandarna = anvandareRepository.GetAnvandare();
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
        public bool kollaEpost(string email)
        {
            IEnumerable<Anvandare> anvandarna = anvandareRepository.GetAnvandare();
            foreach (Anvandare anvandaren in anvandarna)
            {
                if (anvandaren.Epost == email)
                {
                    return false;
                }
            }
            return true;
        }
        private AirBNBDataLayer.Context.AirBNBContext a = new AirBNBDataLayer.Context.AirBNBContext();
        private AirBNBDataLayer.DataManager b = new AirBNBDataLayer.DataManager();
        private AirBNBDataLayer.Internals.Unitofwork unitofwork;
    }
}
