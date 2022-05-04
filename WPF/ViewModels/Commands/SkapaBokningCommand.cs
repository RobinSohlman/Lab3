using AirBNBBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.ViewModels.SkapaBokning;

namespace WPF.ViewModels.Commands
{
    class SkapaBokningCommand : ICommand
    {
        private readonly SkapaBokningModel skapaBokningModel;
        public SkapaBokningCommand(SkapaBokningModel skapaBokningModel)
        {
            this.skapaBokningModel = skapaBokningModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            bokningController = new BokningController();
        int antalPersoner = skapaBokningModel.AntalPersoner;
        
        DateTime StartDatum = skapaBokningModel.StartDatum;
        DateTime SlutDatum = skapaBokningModel.SlutDatum;
        if (StartDatum > DateTime.Today && StartDatum < SlutDatum)
        {
            bokningController.SkapaBokning(skapaBokningModel.VisaAnnons.Annons, skapaBokningModel.Inloggad, antalPersoner, StartDatum, SlutDatum, skapaBokningModel.VisaAnnons.Bostad);
            MessageBox.Show("Bokning Skapad");
        }
        else
        {
             MessageBox.Show("Tidenrna var ej korrekta");
        }  
        }
        private BokningController bokningController;
    }
}
