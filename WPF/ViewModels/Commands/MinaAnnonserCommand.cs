using System;
using System.Collections.Generic;
using AirBNBBL;
using System;
using System.Collections.Generic;
using AirBNBBL;
using AirBNBDataLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.ViewModels.MinaAnnonser;
using WPF.Views;
using System.Windows;
using WPF.ViewModels.Commands;

namespace WPF.ViewModels.Commands
{
    class MinaAnnonserCommand : ICommand
    {
        private readonly MinaAnnonserModel minaAnnonserModel;
        public MinaAnnonserCommand(MinaAnnonserModel minaAnnonserModel)
        {
            this.minaAnnonserModel = minaAnnonserModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
 
        }
    }
}
