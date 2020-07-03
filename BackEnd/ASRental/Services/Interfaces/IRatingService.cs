using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public interface IRatingService
    {
        public Task<List<Rating>> GetAllRatings();
        public Task<Rating> GetRatingById(Guid id);
        public Task<bool> UpdateRating(Guid id, Rating rating);
        public Task<bool> CreateRating(Rating rating);
        public Task<bool> DeleteRating(Guid id);
        public bool RatingExists(Guid id);
    }
}
