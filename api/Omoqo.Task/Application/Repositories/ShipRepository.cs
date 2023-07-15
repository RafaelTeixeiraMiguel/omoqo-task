using Domain.Entities;
using Domain.Interfaces.Repositories;
using Persistence;

namespace Application.Repositories
{
    public class ShipRepository : BaseRepository<Ship>, IShipRepository
    {
        public ShipRepository(DataContext context) : base(context) { }
    }
}
