using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace API.Test.Repositories.Mocks
{
    public class ShipRepositoryMock : BaseRepositoryMock<Ship>, IShipRepository
    {
        public ShipRepositoryMock()
        {
            PopulateShips().GetAwaiter();
        }

        private async Task PopulateShips()
        {
            List<Ship> ships = new List<Ship>()
            {
                new Ship
                {
                    Id = new Guid("0c9dd3d0-2616-4848-b386-be987eadbbb1"),
                    Name = "MSC CANEBERRA",
                    Length = 202.8M,
                    Width = 30.6M,
                    Code = "AAAA-1111-A1",
                },
                new Ship
                {
                    Id = new Guid("0ff8e0db-8131-4c53-b721-d94748538d9a"),
                    Name = "QUEEN MARY 2",
                    Length = 344.3M,
                    Width = 48.7M,
                    Code = "AAAA-1111-A2",
                },
                new Ship
                {
                    Id = new Guid("434f62f0-9fd9-44e2-8d16-6f941a3109c5"),
                    Name = "EVER GIVEN",
                    Length = 399.94M,
                    Width = 59M,
                    Code = "AAAA-1111-A3",
                },
            };

            foreach (var ship in ships)
            {
                await Create(ship);
            }
        }
    }
}
