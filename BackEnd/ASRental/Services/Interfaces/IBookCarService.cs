using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public  interface IBookCarService
    {
        public Task<List<BookCar>> GetAllBookCars();
        public Task<BookCar> GetBookCarById(Guid id);
        public Task<bool> UpdateBookCar(Guid id, BookCar bookCar);
        public Task<bool> CreateBookCar(BookCar bookCar);
        public Task<bool> DeleteBookCar(Guid id);
        public bool BookCarExists(Guid id);
    }
}