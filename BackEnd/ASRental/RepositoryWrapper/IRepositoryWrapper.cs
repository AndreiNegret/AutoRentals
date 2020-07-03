using ASRental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IBookCarRepository Bookcar { get; }

        void Save();
    }
}