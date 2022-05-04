using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.Menyn;

namespace WPF.ViewModels.Commands
{
    public class OpenHanteraEnBokning : ICommand
    {
        private readonly MenyModel menyModel;
        public OpenHanteraEnBokning(MenyModel menyModel)
        {
            this.menyModel = menyModel;
            menyModel.PropertyChanged += CheckIfCanExecute;
        }
        private void CheckIfCanExecute(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(menyModel.ValdBokning))
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return menyModel.ValdBokning != null;
        }
        public void Execute(object parameter)
        {
            WPF.Views.VisaEnBokning visaEnBokningView = new WPF.Views.VisaEnBokning(menyModel.ValdBokning);
            visaEnBokningView.ShowDialog();

        }
    }
}
