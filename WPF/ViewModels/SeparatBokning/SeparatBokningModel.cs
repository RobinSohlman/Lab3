using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Model;
using WPF.ViewModels.Commands;

namespace WPF.ViewModels.SeparatBokning
{
    public class SeparatBokningModel : BaseViewModel
    {
        public BokningOchBostad ValdBokning;
        public string BostadsId { get; set; }
        public string BokningsId { get; set; }
        public string StartDatum { get; set; }
        public string SlutDatum { get; set; }
        public ICommand NewTaBortEnBokning { get; set; }

        public SeparatBokningModel(BokningOchBostad valdBokning)
        {
            ValdBokning = valdBokning;
            BostadsId = "BostadsID: " + valdBokning.Bostad.BostadID;
            BokningsId = "BokningsID: " + valdBokning.Bokning.ID;
            StartDatum = "Startdatum: " + valdBokning.Bokning.StartDatum;
            SlutDatum = "Slutdatum: " + valdBokning.Bokning.SlutDatum;
            NewTaBortEnBokning = new TaBortBokningCommand(this);
        }
    }
}
