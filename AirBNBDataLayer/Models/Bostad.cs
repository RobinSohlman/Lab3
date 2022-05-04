using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class Bostad
    {
        public int BostadID { get; set; }
        public List<Review> ListaAvReview = new List<Review>();
        public List<BostadsAnnons> ListaAvAnnons = new List<BostadsAnnons>();
        public List<Bokning> ListaAvBokningar = new List<Bokning>();
        public string Adress { get; set; }
        public string Stad { get; set; }
        public int AnvandareID { get; set; }
        public Bostad(string adress, string stad, Anvandare anvandare)
        {
            AnvandareID = anvandare.AnvandareID;
            Adress = adress;
            Stad = stad;
        }
        public Bostad()
        {

        }
    }
}
