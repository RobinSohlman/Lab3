using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.MinaAnnonser;

namespace WPF.ViewModels.Commands
{
    class OpenHanteraEnAnnonsCommand : ICommand
    {
        private readonly MinaAnnonserModel minaAnnonserModel;
        public OpenHanteraEnAnnonsCommand(MinaAnnonserModel minaAnnonserModel)
        {
            this.minaAnnonserModel = minaAnnonserModel;
            minaAnnonserModel.PropertyChanged += CheckIfCanExecute;
        }
        private void CheckIfCanExecute(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(minaAnnonserModel.ValdAnnons))
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return minaAnnonserModel.ValdAnnons != null;
        }
        public void Execute(object parameter)
        {
            WPF.Views.HanteraEnAnnons hanteraEnAnnonsView = new WPF.Views.HanteraEnAnnons(minaAnnonserModel.ValdAnnons);
            hanteraEnAnnonsView.ShowDialog();
            minaAnnonserModel.RefreshLista();
            
        }
    }
}
