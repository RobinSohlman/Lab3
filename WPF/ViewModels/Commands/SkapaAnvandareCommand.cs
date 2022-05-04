using System;
using System.Collections.Generic;
using AirBNBBL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.SkapaAnvandare;
using WPF.Views;
using System.Windows;

namespace WPF.ViewModels.Commands
{
    public class SkapaAnvandareCommand : ICommand
    {
        private readonly SkapaAnvandreModel skapaAnvandareModel;
        public SkapaAnvandareCommand(SkapaAnvandreModel skapaAnvandareModel)
        {
            this.skapaAnvandareModel = skapaAnvandareModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            anvandarController = new AnvandarController();
            string epost = skapaAnvandareModel.Epost;
            if (anvandarController.kollaEpost(epost))
            {
                string losenord = skapaAnvandareModel.Losenord;
                string namn = skapaAnvandareModel.Namn;
                anvandarController.AnvandarSkapning(namn, epost, losenord);
                MessageBox.Show("Anvandaren är skapad");
            }
            else
            {
                MessageBox.Show("Eposten finns redan!");
            }
        }
        private AnvandarController anvandarController;
    }
}
