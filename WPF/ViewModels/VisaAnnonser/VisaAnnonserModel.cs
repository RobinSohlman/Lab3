using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Commands;
using System.Windows.Input;
using AirBNBDataLayer;
using System.Collections.ObjectModel;
using WPF.Model;

namespace WPF.ViewModels.VisaAnnonser
{
    class VisaAnnonserModel : BaseViewModel
    {
        private BostadOchAnnons valdAnnons;
        public BostadOchAnnons ValdAnnons { get => valdAnnons; set { valdAnnons = value; OnPropertyChanged(); } }
        public Anvandare Inloggad { get; set; }
        public string FilterStad { get; set; }
        public int FilterAntalRum { get; set; }
        public int FilterPPN { get; set; }
        public int FilterBetyg { get; set; }
        public bool FilterNejWIFI { get; set; }
        public bool FilterJaWIFI { get; set; }
        public bool FilterNejParkering { get; set; }
        public bool FilterJaParkering { get; set; }
        public bool FilterNejHusdjur { get; set; }
        public bool FilterJaHusdjur { get; set; }
        public bool FilterNejRokning { get; set; }
        public bool FilterJaRokning { get; set; }

        public ICommand NewVisaAnnonser { get; set; }
        public ICommand OpenNewAnnons { get; set; }
        public ICommand OpenNewSkapaBokningModel { get; set; }
        public ObservableCollection<BostadOchAnnons> BostadsAnnonser { get; set; } = new ObservableCollection<BostadOchAnnons>();
        public VisaAnnonserModel(Anvandare inloggad)
        {
            Inloggad = inloggad;
            NewVisaAnnonser = new VisaAnnonserCommand(this);
            //OpenNewAnnons = new SeparatAnnonsCommand(this);
            OpenNewSkapaBokningModel = new OpenSkapaBokningCommand(this);
        }
        internal void RefreshAnnonser(List<BostadsAnnons> BostadsAnnonser)
        {
            //BostadsAnnonser.Clear();
            foreach(BostadsAnnons annons in BostadsAnnonser)
            {
                BostadsAnnonser.Add(annons);
            }
        }
    }
}
