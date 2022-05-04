using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Commands;
using System.Windows.Input;
using AirBNBDataLayer;

namespace WPF.ViewModels.SkapaAnnons
{
    public class SkapaAnnonsModel : BaseViewModel
    {
        public Anvandare Inloggad { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public string Beskrivning { get; set; }
        public int PPN { get; set; }
        public int AntalRum { get; set; }
        public bool WIFI { get; set; }
        public bool Parkering { get; set; }
        public bool Husdjur { get; set; }
        public bool Rokning { get; set; }
        public string BildURL { get; set; }

        public ICommand SkapaNewAnnonsCommand { get; set; }

        public SkapaAnnonsModel(Anvandare inloggad)
        {
            Inloggad = inloggad;
            SkapaNewAnnonsCommand = new SkapaAnnonsCommand(this);
        }
    }
}
