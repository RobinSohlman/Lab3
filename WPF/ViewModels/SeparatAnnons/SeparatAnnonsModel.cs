
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirBNBDataLayer;
using WPF.ViewModels.Commands;
using System.Windows.Input;

namespace WPF.ViewModels.SeparatAnnons
{
    public class SeparatAnnonsModel : BaseViewModel
    {
        public BostadsAnnons VisaAnnons { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public string Beskrivning { get; set; }
        public int PPN { get; set; }
        public int AntalRum { get; set; }
        public bool WIFI { get; set; }
        public bool Parkering { get; set; }
        public bool Husdjur { get; set; }
        public bool Rokning { get; set; }

        public ICommand SeparatAnnonsCommand { get; set; }

        public SeparatAnnonsModel(BostadsAnnons visaAnnons)
        {
            VisaAnnons = visaAnnons;
            SeparatAnnonsCommand = new SeparatAnnonsCommand(this);
        }
    }
}

