using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public interface IDriverService
    {
            public Task<List<Driver>> GetAllDrivers();
            public Task<Driver> GetDriverById(Guid id);
            public Task<bool> UpdateDriver(Guid id, Driver driver);
            public Task<bool> CreateDriver(Driver driver);
            public Task<bool> DeleteDriver(Guid id);
            public bool DriverExists(Guid id);
       
    }
}
