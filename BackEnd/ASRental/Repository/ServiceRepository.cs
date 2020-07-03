using ASRental.Data;
using ASRental.Models;
using ASRental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Repository
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
