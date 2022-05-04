using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class Bostad
    {
        public int ID { get; set; }
        public Anvandare Anvandare { get; set; }

        public List<Review> ListaAvReview = new List<Review>();
        public string Adress { get; set; }
        public string Stad { get; set; }

        public Bostad(string adress, string stad, Anvandare anvandare)
        {
            Anvandare = anvandare;
            Adress = adress;
            Stad = stad;
        }
        public Bostad()
        {

        }
    }
}
