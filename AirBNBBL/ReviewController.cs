using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirBNBDataLayer;
using AirBNBDataLayer.Internals;

namespace AirBNBBL
{
    public class ReviewController
    {
        private AirBNBDataLayer.Internals.IReviewRepository reviewRepository;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Review ReviewSkapning(Anvandare anvandare, string recension, int betyg, Bostad bostad)
        {
            Review r = new Review(anvandare, recension, betyg, bostad);
            unitOfWork.ReviewRepository.Insert(r);
            unitOfWork.ReviewRepository.Save();
            return r;
        }
        public bool ReviewBorttagning(int ID)
        {
            Review r = unitOfWork.ReviewRepository.GetByID(ID);
            unitOfWork.ReviewRepository.Delete(r);
            unitOfWork.ReviewRepository.Save();
            return true;
        }
        public IEnumerable<Review> HamtaAllaReviews()
        {
            return unitOfWork.ReviewRepository.Get();
        }
        public Review HamtaSpecifikrReview(int id)
        {
            return unitOfWork.ReviewRepository.GetByID(id);
        }
        public bool KollaReview(int reviewID)
        {
            Review b = unitOfWork.ReviewRepository.GetByID(reviewID);
            if (b != null)
            {
                return true;
            }
            return false;
        }
        public float BeraknaAvgBetyg(int BostadsID)
        {
            float AvgBetyg = 0;
            List<Review> reviews = unitOfWork.ReviewRepository.Get().ToList();
            List<Review> BostadsReviews = reviews.Where(a => a.BostadID == BostadsID).ToList();
            foreach(Review review in BostadsReviews)
            {
                AvgBetyg = AvgBetyg + review.Betyg;
            }
            AvgBetyg = AvgBetyg / BostadsReviews.Count;
            return AvgBetyg;
        }
    }
}
