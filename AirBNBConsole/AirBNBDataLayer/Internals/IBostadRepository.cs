using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public interface IBostadRepository
    {
        IEnumerable<Bostad> GetBostad();
        Bostad GetBostadByID(int bostadID);
        void InsertBostad(Bostad bostad);
        void DeleteBostad(int bostadID);
        void UpdateBostad(Bostad bostad);
        void Save();
    }
}
