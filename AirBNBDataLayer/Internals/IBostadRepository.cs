using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public interface IBostadRepository : IGenericRepository<Bostad>
    {
        void Save();
    }
}
