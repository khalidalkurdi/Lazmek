
using DataAccess.Db;
using DataAccess.InterfacesRepository;
using Models;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ReviewRepository : Repository<Review> , IReviewtRepository
    {
        private readonly ApplicationDbContext _db;
        public ReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Review review)
        {
           _db.Reviews.Update(review);
        }
    }
}
