using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public interface ICarService
    {
        public Task<List<Car>> GetAllCars();
        public Task<Car> GetCarById(Guid id);
        public Task<bool> UpdateCar(Guid id, Car car);
        public Task<bool> CreateCar(Car car);
        public Task<bool> DeleteCar(Guid id);
        public bool CarExists(Guid id);
    }
}
