using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer.Internals
{
    interface IReviewRepository
    {
        IEnumerable<Review> GetReview();
        Review GetReviewByID(int reviewID);
        void InsertReview(Review review);
        void DeleteReview(int reviewID);
        void UpdateReview(Review review);
        void Save();
    }
}
