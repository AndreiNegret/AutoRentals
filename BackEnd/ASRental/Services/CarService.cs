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
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<bool> CreateCar(Car car)
        {
            try
            {
                _carRepository.Create(car);
                await _carRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteCar(Guid id)
        {
            try
            {
                var car = await GetCarById(id);
                _carRepository.Delete(car);
                await _carRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<Car>> GetAllCars()
        {
            try
            {
                return _carRepository.FindAll().OrderBy(car => car.CarName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<Car> GetCarById(Guid id)
        {
            try
            {
                return _carRepository.FindByCondition(car => car.CarId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateCar(Guid id, Car car)
        {
            try
            {
                await GetCarById(id);
                _carRepository.Update(car);
                await _carRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool CarExists(Guid id)
        {
            return _carRepository.FindByCondition(e => e.CarId == id).Any();
        }
    }
}
