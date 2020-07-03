using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
   public interface IServiceService
    {
        public Task<List<Service>> GetAllServices();
        public Task<Service> GetServiceById(Guid id);
        public Task<bool> UpdateService(Guid id, Service service);
        public Task<bool> CreateService(Service service);
        public Task<bool> DeleteService(Guid id);
        public bool ServiceExists(Guid id);
    }
}
