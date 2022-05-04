using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    interface IBokningRepository
    {
        IEnumerable<Bokning> GetBokning();
        Bokning GetBokningByID(int bokningID);
        void InsertBokning(Bokning bokning);
        void DeleteBokning(int bokningID);
        void UpdateBokning(Bokning bokning);
        void Save();
    }
}
