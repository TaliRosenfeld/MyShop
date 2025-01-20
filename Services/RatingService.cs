using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingService:IRatingService
    {
        IRatingRepository _IRatingRepository;
        public RatingService(IRatingRepository IRatingRepository)
        {
            _IRatingRepository = IRatingRepository;
        }
        public  void addRating(Rating Rating)
        {
            _IRatingRepository.addRating(Rating);
        }
    }
}
