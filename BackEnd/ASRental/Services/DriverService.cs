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
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<bool> CreateDriver(Driver driver)
        {
            try
            {
                _driverRepository.Create(driver);
                await _driverRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteDriver(Guid id)
        {
            try
            {
                var driver = await GetDriverById(id);
                _driverRepository.Delete(driver);
                await _driverRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<Driver>> GetAllDrivers()
        {
            try
            {
                return _driverRepository.FindAll().OrderByDescending(driver => driver.DriverName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<Driver> GetDriverById(Guid id)
        {
            try
            {
                return _driverRepository.FindByCondition(driver => driver.DriverId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateDriver(Guid id, Driver driver)
        {
            try
            {
                await GetDriverById(id);
                _driverRepository.Update(driver);
                await _driverRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool DriverExists(Guid id)
        {
            return _driverRepository.FindByCondition(e => e.DriverId == id).Any();
        }
    }
}