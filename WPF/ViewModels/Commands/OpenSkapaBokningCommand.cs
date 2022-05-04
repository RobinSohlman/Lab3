using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.VisaAnnonser;
using AirBNBBL;

namespace WPF.ViewModels.Commands
{
    class OpenSkapaBokningCommand : ICommand
    {
        private readonly VisaAnnonserModel visaAnnonserModel;
        public OpenSkapaBokningCommand(VisaAnnonserModel visaAnnonserModel)
        {
            this.visaAnnonserModel = visaAnnonserModel;
            visaAnnonserModel.PropertyChanged += CheckIfCanExecute;
        }
        private void CheckIfCanExecute(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(visaAnnonserModel.ValdAnnons))
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return visaAnnonserModel.ValdAnnons != null;
        }
        public void Execute(object parameter)
        {
            bokningController = new BokningController();
            WPF.Views.Boka boka = new WPF.Views.Boka(visaAnnonserModel.ValdAnnons, visaAnnonserModel.Inloggad, bokningController.HamtaAllaBokningar());
            boka.ShowDialog();

        }
        private BokningController bokningController;
    }
}
