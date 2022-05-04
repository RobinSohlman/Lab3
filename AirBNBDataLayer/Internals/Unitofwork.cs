using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    public class UnitOfWork : IUnitofwork
    {
        private AirBNBDataLayer.Context.AirBNBContext context = new AirBNBDataLayer.Context.AirBNBContext();
        private GenericRepository<Anvandare> anvandareRepository;
        private GenericRepository<Review> reviewRepository;
        public GenericRepository<Anvandare> AnvandareRepository
        {
            get
            {
                if (this.anvandareRepository == null)
                {
                    this.anvandareRepository = new GenericRepository<Anvandare>(context);
                }
                return anvandareRepository;
            }
        }
        public GenericRepository<Review> ReviewRepository
        {
            get
            {

                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new GenericRepository<Review>(context);
                }
                return reviewRepository;
            }
        }
    }
}

