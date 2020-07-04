using ASRental.Models;
using ASRental.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceService(IServiceRepository ServiceRepository)
        {
            _serviceRepository = ServiceRepository;
        }

        public async Task<bool> CreateService(Service service)
        {
            try
            {
                _serviceRepository.Create(service);
                await _serviceRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteService(Guid id)
        {
            try
            {
                var service = await GetServiceById(id);
                _serviceRepository.Delete(service);
                await _serviceRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<Service>> GetAllServices()
        {
            try
            {
                return _serviceRepository.FindAll().OrderBy(service => service.ServiceType).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<Service> GetServiceById(Guid id)
        {
            try
            {
                return _serviceRepository.FindByCondition(service => service.ServiceId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateService(Guid id, Service service)
        {
            try
            {
                await GetServiceById(id);
                _serviceRepository.Update(service);
                await _serviceRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool ServiceExists(Guid id)
        {
            return _serviceRepository.FindByCondition(e => e.ServiceId == id).Any();
        }
    }
}