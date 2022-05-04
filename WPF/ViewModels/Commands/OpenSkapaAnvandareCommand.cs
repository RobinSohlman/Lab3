using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.LoggaIn;
using WPF.Views;

namespace WPF.ViewModels.Commands
{
    public class OpenSkapaAnvandareCommand : ICommand
    {
        private readonly LoggaInModel loggaInModel;
        public OpenSkapaAnvandareCommand(LoggaInModel loggaInModel)
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
            WPF.Views.SkapaAnvandare skapaAnvandareView = new WPF.Views.SkapaAnvandare();
            skapaAnvandareView.ShowDialog();
        }
    }
}
