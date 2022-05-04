using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public interface IBostadsAnnonsRepository
    {
        IEnumerable<BostadsAnnons> GetBostadsAnnons();
        BostadsAnnons GetBostadsAnnonsByID(int bostadsAnnonsID);
        void InsertBostadsAnnons(BostadsAnnons bostadsAnnons);
        void DeleteBostadsAnnons(int bostadsAnnonsID);
        void UpdateBostadsAnnons(BostadsAnnons bostadsAnnons);
        void Save();
    }
}
