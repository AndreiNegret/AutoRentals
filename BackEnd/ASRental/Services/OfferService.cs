using ASRental.Models;
using ASRental.Repository.Interfaces;
using ASRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<bool> CreateOffer(Offer offer)
        {
            try
            {
                _offerRepository.Create(offer);
                await _offerRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteOffer(Guid id)
        {
            try
            {
                var offer = await GetOfferById(id);
                _offerRepository.Delete(offer);
                await _offerRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<Offer>> GetAllOffers()
        {
            try
            {
                return _offerRepository.FindAll().OrderByDescending(offer => offer.Price).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<Offer> GetOfferById(Guid id)
        {
            try
            {
                return _offerRepository.FindByCondition(offer => offer.OfferId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateOffer(Guid id, Offer offer)
        {
            try
            {
                await GetOfferById(id);
                _offerRepository.Update(offer);
                await _offerRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool OfferExists(Guid id)
        {
            return _offerRepository.FindByCondition(e => e.OfferId == id).Any();
        }
    }
}