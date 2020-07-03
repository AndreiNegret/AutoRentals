using ASRental.Repository.Interfaces;

namespace ASRental.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IBookCarRepository BookCar { get; }
        ICarRepository Car { get; }
        IContactRepository Contact { get; }
        IDriverRepository Driver { get; }
        IFactRepository Fact { get; }
        IOfferRepository Offer { get; }
        IRatingRepository Rating { get; }
        IServiceRepository Service { get; }
        ITeamMemberRepository TeamMember { get; }
        IUserRepository User { get; }

        void Save();
    }
}