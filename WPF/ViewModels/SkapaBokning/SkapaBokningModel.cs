using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;
using AirBNBDataLayer;
using System.Windows.Input;
using WPF.ViewModels.Commands;
using System.Collections.ObjectModel;
using AirBNBBL;

namespace WPF.ViewModels.SkapaBokning
{
    public class SkapaBokningModel : BaseViewModel
    {
        public BostadOchAnnons VisaAnnons { get; set; }
        public Anvandare Inloggad { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public string Beskrivning { get; set; }
        public string PPN { get; set; }
        public string AntalRum { get; set; }
        public string WIFI { get; set; }
        public string Parkering { get; set; }
        public string Husdjur { get; set; }
        public string Rokning { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public int AntalPersoner { get; set; }
        public int Betyg { get; set; }
        public string Recension { get; set; }
        public string BildURL { get; set; }
        public ICommand NewSkapaBokningCommand { get; set; }
        public ICommand NewSkapaRecensionCommand { get; set; }
        public ObservableCollection<Review> reviews { get; set; } = new ObservableCollection<Review>();
        public ObservableCollection<DateTime> upptagnaDagar { get; set; } = new ObservableCollection<DateTime>();

        public SkapaBokningModel(BostadOchAnnons visaAnnons, Anvandare inloggad)
        {
            Inloggad = inloggad;
            VisaAnnons = visaAnnons;
            Adress = "Adress: " + visaAnnons.Bostad.Adress;
            Stad = "Stad: " + visaAnnons.Bostad.Stad;
            Beskrivning = "Beskrivning: " + visaAnnons.Annons.Beskrivning;
            PPN = "PPN: " + visaAnnons.Annons.PPN;
            AntalRum = "AntalRum: " + visaAnnons.Annons.AntalRum;
            WIFI = "WIFI: " + visaAnnons.Annons.WIFI;
            Parkering = "Parkering: " + visaAnnons.Annons.Parkering;
            Husdjur = "Husdjur: " + visaAnnons.Annons.Husdjur;
            Rokning = "Rokning: " + visaAnnons.Annons.Rokning;
            BildURL = visaAnnons.Annons.BildURL;
            NewSkapaBokningCommand = new SkapaBokningCommand(this);
            NewSkapaRecensionCommand = new SkapaRecensionCommand(this);
            reviewController = new ReviewController();
            bokningController = new BokningController();
            RefreshListor();
            RefreshCalendar();
        }
        internal void RefreshListor()
        {
            reviews.Clear();
            List<Review> AnnonsReviews = reviewController.HamtaAllaReviews().Where(x => x.BostadID == VisaAnnons.Bostad.BostadID).ToList();
            foreach (Review review in AnnonsReviews)
            {
                    reviews.Add(review);
            }
        }
        internal void RefreshCalendar()
        {
            upptagnaDagar.Clear();
            List<DateTime> tagnaDagar = bokningController.HamtaAllaUpptagnaDagar(VisaAnnons.Bostad.BostadID);
            foreach(DateTime dag in tagnaDagar)
            {
                upptagnaDagar.Add(dag);
            }
            
        }
        private ReviewController reviewController;
        private BokningController bokningController;
    }
}
