using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Commands;
using System.Windows.Input;
using AirBNBDataLayer;
using System.Collections.ObjectModel;
using AirBNBBL;
using WPF.Model;

namespace WPF.ViewModels.MinaAnnonser
{
    public class MinaAnnonserModel : BaseViewModel
    {
        public Anvandare Inloggad;
        private BostadOchAnnons valdAnnons;
        public BostadOchAnnons ValdAnnons { get => valdAnnons; set { valdAnnons = value; OnPropertyChanged(); } }
        public string AnnonsID { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public ObservableCollection<BostadOchAnnons> BostadsAnnonser { get; set; } = new ObservableCollection<BostadOchAnnons>();
        public ICommand NewMinaAnnonser { get; set; }
        public ICommand OpenNewHanteraEnAnnonsCommand { get; set; }
        public MinaAnnonserModel(Anvandare inloggad)
        {
            Inloggad = inloggad;
            bostadsAnnonsController = new BostadsAnnonsController();
            bostadController = new BostadController();

            NewMinaAnnonser = new MinaAnnonserCommand(this);
            OpenNewHanteraEnAnnonsCommand = new OpenHanteraEnAnnonsCommand(this);
            anvandarController = new AnvandarController();

            reviewController = new ReviewController();
            bokningController = new BokningController();
            RefreshLista();
        }
        public void RefreshLista()
        {
            BostadsAnnonser.Clear();
            List<BostadsAnnons> AnnonserAttVisa = new List<BostadsAnnons>();
            AnnonserAttVisa = bostadsAnnonsController.HamtaAllaAnnonser().Where(x => bostadController.HamtaSpecifikBostad(x.BostadID).AnvandareID == Inloggad.AnvandareID).ToList();

            foreach (BostadsAnnons bostadsAnnons in AnnonserAttVisa)
            {
                if (bostadsAnnons.Status == true)
                {
                    BostadOchAnnons a = new BostadOchAnnons(bostadsAnnons, bostadController.HamtaSpecifikBostad(bostadsAnnons.BostadID));
                    BostadsAnnonser.Add(a);
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
