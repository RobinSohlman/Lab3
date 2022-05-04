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
            bostadRepository.InsertBostad(b);
            bostadRepository.Save();
            return b;
        }
    }
}
