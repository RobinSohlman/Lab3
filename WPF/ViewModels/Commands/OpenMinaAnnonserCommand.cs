using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.Menyn;
using System.Windows;
using AirBNBBL;
using AirBNBDataLayer;
using WPF.ViewModels.MinaAnnonser;
using WPF.ViewModels.VisaAnnonser;

namespace WPF.ViewModels.Commands
{
    public class OpenMinaAnnonserCommand : ICommand
    {
        private readonly MenyModel menyModel;
        public OpenMinaAnnonserCommand(MenyModel menyModel)
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
            WPF.Views.MinaAnnonser minaAnnonser = new WPF.Views.MinaAnnonser(menyModel.Inloggad);
            minaAnnonser.ShowDialog();
        }
    }
}


