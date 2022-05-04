using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AirBNBBL;
using System.Windows;
using WPF.ViewModels.LoggaIn;
using WPF.Views;

namespace WPF.ViewModels.Commands
{
    class LoggaInCommand : ICommand
    {

        private readonly LoggaInModel loggaInModel;
        public LoggaInCommand(LoggaInModel loggaInModel)
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
            anvandarController = new AnvandarController();
            string epost = loggaInModel.Epost;
            string losenord = loggaInModel.Losenord;
            if(anvandarController.LoggaInAnvandare(epost, losenord))
            {
                WPF.Views.Menyn menyn = new WPF.Views.Menyn(anvandarController.Inloggad);
                menyn.ShowDialog();

            }
            else
            {
                MessageBox.Show("Inmatade uppgifter är felaktiga!");
            }
        }
        private AnvandarController anvandarController;
    }
}
