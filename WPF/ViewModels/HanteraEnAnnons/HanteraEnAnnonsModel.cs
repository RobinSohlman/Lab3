using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Model;
using WPF.ViewModels.Commands;

namespace WPF.ViewModels.HanteraEnAnnons
{
    public class HanteraEnAnnonsModel : BaseViewModel
    {
        public BostadOchAnnons ValdAnnons { get; set; }
        public string VisaAdress { get; set; }
        public string VisaStad { get; set; }
        public string VisaBeskrivning { get; set; }
        public int VisaPPN { get; set; }
        public int VisaAntalRum { get; set; }
        public bool VisaWifi { get; set; }
        public bool VisaRokning { get; set; }
        public bool VisaHusdjur { get; set; }
        public bool VisaParkering { get; set; }
        public string VisaBildURL  { get; set; }

        public ICommand NewAndraEnAnnons { get; set; }
        public ICommand NewTaBortEnAnnons { get; set; }

        public HanteraEnAnnonsModel(BostadOchAnnons valdAnnons)
        {
            ValdAnnons = valdAnnons;
            VisaAdress = valdAnnons.Bostad.Adress;
            VisaStad = valdAnnons.Bostad.Stad;
            VisaBeskrivning = valdAnnons.Annons.Beskrivning;
            VisaPPN = valdAnnons.Annons.PPN;
            VisaAntalRum = valdAnnons.Annons.AntalRum;
            VisaParkering = valdAnnons.Annons.Parkering;
            VisaWifi = valdAnnons.Annons.WIFI;
            VisaRokning = valdAnnons.Annons.Rokning;
            VisaHusdjur = valdAnnons.Annons.Husdjur;
            VisaBildURL = valdAnnons.Annons.BildURL;
            NewAndraEnAnnons = new AndraAnnonsCommand(this);
            NewTaBortEnAnnons = new TaBortAnnonsCommand(this);
        }
    }
}
