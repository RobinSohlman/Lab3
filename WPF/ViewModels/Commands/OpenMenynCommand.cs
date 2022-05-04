using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.LoggaIn;
using System.Windows;
using AirBNBBL;


namespace WPF.ViewModels.Commands
{
    class OpenMenynCommand : ICommand
    {
        private readonly LoggaInModel loggaInModel;
        public OpenMenynCommand(LoggaInModel loggaInModel)
        {
            this.loggaInModel = loggaInModel;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            //WPF.Views.Menyn menyn = new WPF.Views.Menyn(loggaInModel.InloggadID);
            //menyn.ShowDialog();
        }
    }
}
