using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.Menyn;
using WPF.Views;

namespace WPF.ViewModels.Commands
{
    class OpenVisaAnnonserCommand : ICommand
    {
        private readonly MenyModel menyModel;
        public OpenVisaAnnonserCommand(MenyModel menyModel)
        {
            this.menyModel = menyModel;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            WPF.Views.VisaAnnonser skapaAnnonserView = new WPF.Views.VisaAnnonser(menyModel.Inloggad);
            skapaAnnonserView.ShowDialog();
        }
    }
}
