using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using AirBNBDataLayer.Context;

namespace AirBNBDataLayer.Internals
{
    public class BokningRepository : GenericRepository<Bokning>, IBokningRepository
    {
        public BokningRepository(AirBNBContext context) : base(context)
        {
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
