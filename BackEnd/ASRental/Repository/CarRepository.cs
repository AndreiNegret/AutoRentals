using ASRental.Data;
using ASRental.Models;
using ASRental.Repository.Interfaces;

namespace ASRental.Repository
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
