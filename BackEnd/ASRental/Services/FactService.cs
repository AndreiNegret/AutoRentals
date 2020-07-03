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
    public class FactService : IFactService
    {
        private readonly IFactRepository _factRepository;
        public FactService(IFactRepository factRepository)
        {
            _factRepository = factRepository;
        }

        public async Task<bool> CreateFact(Fact fact)
        {
            try
            {
                _factRepository.Create(fact);
                await _factRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteFact(Guid id)
        {
            try
            {
                var fact = await GetFactById(id);
                _factRepository.Delete(fact);
                await _factRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<Fact>> GetAllFacts()
        {
            try
            {
                return _factRepository.FindAll().OrderByDescending(fact => fact.Title).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<Fact> GetFactById(Guid id)
        {
            try
            {
                return _factRepository.FindByCondition(fact => fact.FactId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateFact(Guid id, Fact fact)
        {
            try
            {
                await GetFactById(id);
                _factRepository.Update(fact);
                await _factRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool FactExists(Guid id)
        {
            return _factRepository.FindByCondition(e => e.FactId == id).Any();
        }
    }
}