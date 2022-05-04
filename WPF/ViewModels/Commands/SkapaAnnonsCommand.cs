using System;
using System.Collections.Generic;
using AirBNBBL;
using AirBNBDataLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.SkapaAnnons;
using WPF.Views;
using System.Windows;
using WPF.ViewModels.Commands;
using WPF.ViewModels.LoggaIn;

namespace WPF.ViewModels.Commands
{
    public class SkapaAnnonsCommand : ICommand
    {
        private readonly SkapaAnnonsModel skapaAnnonsModel;
        public SkapaAnnonsCommand(SkapaAnnonsModel skapaAnnonsModel)
        {
            this.skapaAnnonsModel = skapaAnnonsModel;
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
            string adress = skapaAnnonsModel.Adress;
            string stad = skapaAnnonsModel.Stad;
            Bostad bostad = bostadController.BostadSkapning(adress, stad, skapaAnnonsModel.Inloggad);
            anvandarController.LaggTillNyBostadIListan(bostad, skapaAnnonsModel.Inloggad);
            int ppn = skapaAnnonsModel.PPN;
            string beskrivning = skapaAnnonsModel.Beskrivning;
            int antalRum = skapaAnnonsModel.AntalRum;
            bool wifi = skapaAnnonsModel.WIFI;
            bool parkering = skapaAnnonsModel.Parkering;
            bool husdjur = skapaAnnonsModel.Husdjur;
            bool rokning = skapaAnnonsModel.Rokning;
            string bildurl = skapaAnnonsModel.BildURL;

            bool status = true;
            BostadsAnnons annons = bostadsAnnonsController.AnnonsSkapning(ppn, beskrivning, antalRum, wifi, parkering, husdjur, rokning, status, bostad, bildurl);
            bostadController.LaggTillAnnonsILista(annons, bostad);
            MessageBox.Show("Annonsen är skapad");
        }
        private BostadController bostadController;
        private BostadsAnnonsController bostadsAnnonsController;
        private AnvandarController anvandarController;
    }
}
