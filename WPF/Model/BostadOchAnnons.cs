using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirBNBDataLayer;

namespace WPF.Model
{
    public class BostadOchAnnons
    {
        public BostadsAnnons Annons { get; set; }
        public Bostad Bostad { get; set; }
        public BostadOchAnnons(BostadsAnnons annons, Bostad bostad)
        {
            Annons = annons;
            Bostad = bostad;
        }
    }
}
