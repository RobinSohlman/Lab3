using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public interface IAnvandareRepository
    {
        IEnumerable<Anvandare> GetAnvandare();
        Anvandare GetAnvandareByID(int anvandareID);
        void InsertAnvandare(Anvandare anvandare);
        void DeleteAnvandare(int anvandareID);
        void UpdateAnvandare(Anvandare anvandare);
        void Save();
    }
}
