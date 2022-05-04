using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int SkribentID { get; set; }
        public string Recension { get; set; }
        public int Betyg { get; set; }
        public int BostadID { get; set; }
        public Review(Anvandare anvandare, string recension, int betyg, Bostad bostad)
        {
            BostadID = bostad.BostadID;
            SkribentID = anvandare.AnvandareID;
            Recension = recension;
            Betyg = betyg;
        }
        public Review()
        {
        }
    }
}
