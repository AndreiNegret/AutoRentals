using ASRental.Data;
using ASRental.Repository;
using ASRental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _applicationDbContext;
        private IBookCarRepository _bookCar;
        private ICarRepository _car;
        private IContactRepository _contact;
        private IDriverRepository _driver;
        private IFactRepository _fact;
        private IRatingRepository _rating;
        private IOfferRepository _offer;
        private IServiceRepository _service;
        private ITeamMemberRepository _teamMember;
        private IUserRepository _user;

        public IBookCarRepository BookCar
        {
            get
            {
                if (_bookCar == null)
                {
                    _bookCar = new BookCarRepository(_applicationDbContext);
                }

                return _bookCar;
            }
        }

        public ICarRepository Car
        {
            get
            {
                if (_car == null)
                {
                    _car = new CarRepository(_applicationDbContext);
                }

                return _car;
            }
        }

        public IContactRepository Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_applicationDbContext);
                }

                return _contact;
            }
        }

        public IDriverRepository Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new DriverRepository(_applicationDbContext);
                }

                return _driver;
            }
        }

        public IFactRepository Fact
        {
            get
            {
                if (_fact == null)
                {
                    _fact = new FactRepository(_applicationDbContext);
                }

                return _fact;
            }
        }

        public IRatingRepository Rating
        {
            get
            {
                if (_rating == null)
                {
                    _rating = new RatingRepository(_applicationDbContext);
                }

                return _rating;
            }
        }

        public IOfferRepository Offer
        {
            get
            {
                if (_offer == null)
                {
                    _offer = new OfferRepository(_applicationDbContext);
                }

                return _offer;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_applicationDbContext);
                }

                return _user;
            }
        }

        public IServiceRepository Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new ServiceRepository(_applicationDbContext);
                }

                return _service;
            }
        }

        public ITeamMemberRepository TeamMember
        {
            get
            {
                if (_teamMember == null)
                {
                    _teamMember = new TeamMemberRepository(_applicationDbContext);
                }

                return _teamMember;
            }
        }





        public RepositoryWrapper(ApplicationDbContext repositoryContext)
        {
            _applicationDbContext = repositoryContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
