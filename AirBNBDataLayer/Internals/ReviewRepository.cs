using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public class ReviewRepository : GenericRepository<Review>
    {
        public ReviewRepository(AirBNBDataLayer.Context.AirBNBContext airBNBContext) : base(airBNBContext)
        {
        }
    }
}
