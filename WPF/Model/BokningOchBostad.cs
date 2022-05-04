using AirBNBDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Model
{
    public class BokningOchBostad
    {
        public Bostad Bostad { get; set; }
        public Bokning Bokning { get; set; }
        public BokningOchBostad(Bostad bostad, Bokning bokning)
        {
            Bostad = bostad;
            Bokning = bokning;
        }
    }
}
