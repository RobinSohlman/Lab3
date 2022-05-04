using System;
using System.Collections.Generic;
using AirBNBBL;
using AirBNBDataLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.SeparatBokning;
using WPF.Views;
using System.Windows;
using WPF.ViewModels.Commands;
using WPF.ViewModels.LoggaIn;

namespace WPF.ViewModels.Commands
{
    public class TaBortBokningCommand : ICommand
    {
        private readonly SeparatBokningModel separatBokningModel;
        public TaBortBokningCommand(SeparatBokningModel separatBokningModel)
        {
            this.separatBokningModel = separatBokningModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            bokningsController = new BokningController();
            if (bokningsController.BokningsBorttagning(separatBokningModel.ValdBokning.Bokning.ID))
            {
                MessageBox.Show("Annonsen är nu borttagen");
            }
            MessageBox.Show("Annonsen gick ej att ta bort");
        }
        private BokningController bokningsController;
    }
}
