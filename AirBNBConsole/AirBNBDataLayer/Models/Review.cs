using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class Review
    {
        public int ID { get; set; }
        public Anvandare Anvandare { get; set; }
        public string Recension { get; set; }
        public int Betyg { get; set; }

        internal Review(Anvandare anvandare, string recension, int betyg)
        {
            Anvandare = anvandare;
            Recension = recension;
            Betyg = betyg;
        }
        public Review()
        {

        }
    }
}
