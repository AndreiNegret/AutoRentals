using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
     public interface IFactService
    {
        public Task<List<Fact>> GetAllFacts();
        public Task<Fact> GetFactById(Guid id);
        public Task<bool> UpdateFact(Guid id, Fact fact);
        public Task<bool> CreateFact(Fact fact);
        public Task<bool> DeleteFact(Guid id);
        public bool FactExists(Guid id);
    }
}
