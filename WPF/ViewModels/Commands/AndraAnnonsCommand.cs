using System;
using System.Collections.Generic;
using AirBNBBL;
using AirBNBDataLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.HanteraEnAnnons;
using WPF.Views;
using System.Windows;
using WPF.ViewModels.Commands;
using WPF.ViewModels.LoggaIn;
namespace WPF.ViewModels.Commands
{
    public class AndraAnnonsCommand : ICommand
    {
        private readonly HanteraEnAnnonsModel hanteraEnAnnonsModel;
        public AndraAnnonsCommand(HanteraEnAnnonsModel hanteraEnAnnonsModel)
        {
            this.hanteraEnAnnonsModel = hanteraEnAnnonsModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            bostadController = new BostadController();
            bostadsAnnonsController = new BostadsAnnonsController();
            anvandarController = new AnvandarController();

            int nyttPPN = hanteraEnAnnonsModel.VisaPPN;
            string nyBeskrivning = hanteraEnAnnonsModel.VisaBeskrivning;
            int nyttAntalRum = hanteraEnAnnonsModel.VisaAntalRum;
            bool wifiStatus = hanteraEnAnnonsModel.VisaWifi;
            bool parkeringStatus = hanteraEnAnnonsModel.VisaParkering;
            bool husdjurStatus = hanteraEnAnnonsModel.VisaHusdjur;
            bool rokningStatus = hanteraEnAnnonsModel.VisaRokning;
            string nybildURL = hanteraEnAnnonsModel.VisaBildURL;

            if (nyttPPN == hanteraEnAnnonsModel.ValdAnnons.Annons.PPN && nyBeskrivning == hanteraEnAnnonsModel.ValdAnnons.Annons.Beskrivning && nyttAntalRum == hanteraEnAnnonsModel.ValdAnnons.Annons.AntalRum && wifiStatus == hanteraEnAnnonsModel.ValdAnnons.Annons.WIFI && parkeringStatus == hanteraEnAnnonsModel.ValdAnnons.Annons.Parkering && husdjurStatus == hanteraEnAnnonsModel.ValdAnnons.Annons.Husdjur && rokningStatus == hanteraEnAnnonsModel.ValdAnnons.Annons.Rokning && nybildURL == hanteraEnAnnonsModel.ValdAnnons.Annons.BildURL)
            {
                MessageBox.Show("Inga uppgifter ändrades");
            }
            else
            {
                Bostad b = bostadController.HamtaSpecifikBostad(hanteraEnAnnonsModel.ValdAnnons.Bostad.BostadID);
                int NyttannonsID = bostadsAnnonsController.AnnonsSkapning(nyttPPN, nyBeskrivning, nyttAntalRum, wifiStatus, parkeringStatus, husdjurStatus, rokningStatus, hanteraEnAnnonsModel.ValdAnnons.Annons.Status, b, nybildURL).BostadsAnnonsID;
                bostadsAnnonsController.AnnonsBorttagning(hanteraEnAnnonsModel.ValdAnnons.Annons.BostadsAnnonsID);
                MessageBox.Show("Uppgifterna är nu ändrade");
                
            }
        }
        private BostadController bostadController;
        private BostadsAnnonsController bostadsAnnonsController;
        private AnvandarController anvandarController;
    }
}
