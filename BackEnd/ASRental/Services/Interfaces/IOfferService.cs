using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public  interface IOfferService
    {
        public Task<List<Offer>> GetAllOffers();
        public Task<Offer> GetOfferById(Guid id);
        public Task<bool> UpdateOffer(Guid id, Offer offer);
        public Task<bool> CreateOffer(Offer offer);
        public Task<bool> DeleteOffer(Guid id);
        public bool OfferExists(Guid id);
    }
}
