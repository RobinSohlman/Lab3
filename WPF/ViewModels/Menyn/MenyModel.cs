using System;
using System.Collections.Generic;
using System.Linq;
using AirBNBDataLayer;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Commands;
using System.Windows.Input;
using AirBNBBL;
using WPF.Model;
using System.Collections.ObjectModel;

namespace WPF.ViewModels.Menyn
{
    public class MenyModel : BaseViewModel
    {
        public Anvandare Inloggad;
        public string VisaInloggad;
        private BokningOchBostad valdBokning;
        public BokningOchBostad ValdBokning { get => valdBokning; set { valdBokning = value; OnPropertyChanged(); } }
        public ICommand OpenNewSkapaAnnonsCommand { get; set; }
        public ICommand OpenNewVisaAnnonserCommand { get; set; }
        public ICommand OpenNewMinaAnnonserCommand { get; set; }
        public ICommand OpenNewHanteraEnBokningCommand { get; set; }
        public ObservableCollection<BokningOchBostad> RelevantaBokningar { get; set; } = new ObservableCollection<BokningOchBostad>();
        public MenyModel(Anvandare inloggad)
        {
            Inloggad = inloggad;
            VisaInloggad = "Välkommen" + Inloggad.Namn;
            OpenNewSkapaAnnonsCommand = new OpenSkapaAnnonsCommand(this);
            OpenNewVisaAnnonserCommand = new OpenVisaAnnonserCommand(this);
            OpenNewMinaAnnonserCommand = new OpenMinaAnnonserCommand(this);
            OpenNewHanteraEnBokningCommand = new OpenHanteraEnBokning(this);
            anvandarController = new AnvandarController();
            bostadsAnnonsController = new BostadsAnnonsController();
            bostadController = new BostadController();
            reviewController = new ReviewController();
            bokningController = new BokningController();
            RefreshListor();
            
        }
        internal void RefreshListor()
        {
            RelevantaBokningar.Clear();
            List<Bokning> InloggadesBokningar = bokningController.HamtaAllaBokningar().Where(x => x.KundID == Inloggad.AnvandareID).ToList();
            List<Bokning> AndrasBokningarAvInloggads = bokningController.HamtaAllaBokningar().Where(x => bostadController.HamtaSpecifikBostad(x.BostadID).AnvandareID == Inloggad.AnvandareID).ToList();

            foreach (Bokning bokning in InloggadesBokningar)
            {
                if (bokning.Status == true)
                {               
                    BokningOchBostad a = new BokningOchBostad(bostadController.HamtaSpecifikBostad(bokning.BostadID), bokning);
                    RelevantaBokningar.Add(a);
                }
            }
            foreach (Bokning bokning in AndrasBokningarAvInloggads)
            {
                if (bokning.Status == true)
                {
                    BokningOchBostad a = new BokningOchBostad(bostadController.HamtaSpecifikBostad(bokning.BostadID), bokning);
                    RelevantaBokningar.Add(a);
                }
            }
        }
        private AnvandarController anvandarController;
        private BostadController bostadController;
        private BostadsAnnonsController bostadsAnnonsController;
        private ReviewController reviewController;
        private BokningController bokningController;
    }
}
