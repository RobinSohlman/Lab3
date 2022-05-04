using System;
using System.Collections.Generic;
using AirBNBBL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.VisaAnnonser;
using WPF.Views;
using System.Windows;
using AirBNBDataLayer;
using WPF.Model;


namespace WPF.ViewModels.Commands
{
    class VisaAnnonserCommand : ICommand
    {
        private readonly VisaAnnonserModel visaAnnonserModel;
        public VisaAnnonserCommand(VisaAnnonserModel visaAnnonserModel)
        {
            this.visaAnnonserModel = visaAnnonserModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            bostadsAnnonsController = new BostadsAnnonsController();
            bostadController = new BostadController();
            reviewController = new ReviewController();
            List<BostadsAnnons> bostadsAnnonsernaSomSkaVisas = bostadsAnnonsController.HamtaAllaAnnonser();
            List<BostadsAnnons> Tillfälig = new List<BostadsAnnons>(); 
            string FilterStad = visaAnnonserModel.FilterStad;
            int FilterAntalRum = visaAnnonserModel.FilterAntalRum;
            int FilterPPN = visaAnnonserModel.FilterPPN;
            int FilterBetyg = visaAnnonserModel.FilterBetyg;
            bool FilterJaWIFI = visaAnnonserModel.FilterJaWIFI;
            bool FilterNejWIFI = visaAnnonserModel.FilterNejWIFI;
            bool FilterJaParkering = visaAnnonserModel.FilterJaParkering;
            bool FilterNejParkering = visaAnnonserModel.FilterNejParkering;
            bool FilterJaHusdjur = visaAnnonserModel.FilterJaHusdjur;
            bool FilterNejHusdjur = visaAnnonserModel.FilterNejHusdjur;
            bool FilterJaRokning = visaAnnonserModel.FilterJaRokning;
            bool FilterNejRokning = visaAnnonserModel.FilterNejRokning;

            if (FilterStad == null || FilterStad == "")
            {
            }
            else
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => bostadController.HamtaSpecifikBostad(x.BostadID).Stad == FilterStad).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            if (FilterAntalRum == 0)
            {
            }
            else
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.AntalRum >= FilterAntalRum).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            if (FilterBetyg == 0)
            {
            }
            else
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => reviewController.BeraknaAvgBetyg(x.BostadID) >= FilterBetyg).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            if (FilterPPN == 0)
            {
            }
            else
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.PPN <= FilterPPN).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            if (FilterJaRokning == true)
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.Rokning == true).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            else if (FilterNejRokning == true)
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.Rokning == false).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            else
            {              
            }
            if (FilterJaHusdjur == true)
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.Husdjur == true).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            else if (FilterNejHusdjur == true)
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.Husdjur == false).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            else
            {
            }
            if (FilterJaWIFI == true)
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.WIFI == true).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            else if (FilterNejWIFI == true)
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.WIFI == false).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            else
            {
            }
            if (FilterJaParkering == true)
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.Parkering == true).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            else if (FilterNejParkering == true)
            {
                Tillfälig = bostadsAnnonsernaSomSkaVisas.Where(x => x.Parkering == false).ToList();
                bostadsAnnonsernaSomSkaVisas = Tillfälig;
            }
            else
            {
            }
            visaAnnonserModel.BostadsAnnonser.Clear();
           foreach (BostadsAnnons annons in bostadsAnnonsernaSomSkaVisas)
            {
                if (annons.Status == true)
                {
                    BostadOchAnnons a = new BostadOchAnnons(annons, bostadController.HamtaSpecifikBostad(annons.BostadID));
                    visaAnnonserModel.BostadsAnnonser.Add(a);
                }
            }
        }
        private BostadsAnnonsController bostadsAnnonsController;
        private BostadController bostadController;
        private ReviewController reviewController;
    }
}

