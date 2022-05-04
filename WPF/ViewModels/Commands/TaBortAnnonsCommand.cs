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
    public class TaBortAnnonsCommand : ICommand
    {
        private readonly HanteraEnAnnonsModel hanteraEnAnnonsModel;
        public TaBortAnnonsCommand(HanteraEnAnnonsModel hanteraEnAnnonsModel)
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
            bostadsAnnonsController = new BostadsAnnonsController();
            if (bostadsAnnonsController.AnnonsBorttagning(hanteraEnAnnonsModel.ValdAnnons.Annons.BostadsAnnonsID))
            {
                MessageBox.Show("Annonsen är nu borttagen");
            }
            MessageBox.Show("Annonsen gick ej att ta bort");
        }
        private BostadsAnnonsController bostadsAnnonsController;
    }
}
