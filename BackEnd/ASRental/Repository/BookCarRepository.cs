using ASRental.Data;
using ASRental.Models;
using ASRental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Repository
{
    public class BookCarRepository : RepositoryBase<BookCar>, IBookCarRepository
    {
        public BookCarRepository(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}