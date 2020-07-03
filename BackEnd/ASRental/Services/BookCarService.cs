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
    public class BookCarService : IBookCarService
    {
        private readonly IBookCarRepository _bookCarRepository;
        public BookCarService(IBookCarRepository bookCarRepository )
        {
            _bookCarRepository = bookCarRepository;
        }

        public async Task<bool> CreateBookCar(BookCar bookCar)
        {
            try
            {
                _bookCarRepository.Create(bookCar);
                await _bookCarRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteBookCar(Guid id)
        {
            try
            {
                var bookCar = await GetBookCarById(id);
                _bookCarRepository.Delete(bookCar);
                await _bookCarRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<BookCar>> GetAllBookCars()
        {
            try
            {
                return _bookCarRepository.FindAll().OrderByDescending(bookCar => bookCar.PickDate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<BookCar> GetBookCarById(Guid id)
        {
            try
            {
                return _bookCarRepository.FindByCondition(bookCar => bookCar.BookCarId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateBookCar(Guid id, BookCar bookCar)
        {
            try
            {
                await GetBookCarById(id);
                _bookCarRepository.Update(bookCar);
                await _bookCarRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool BookCarExists(Guid id)
        {
            return _bookCarRepository.FindByCondition(e => e.BookCarId == id).Any();
        }
    }
}
