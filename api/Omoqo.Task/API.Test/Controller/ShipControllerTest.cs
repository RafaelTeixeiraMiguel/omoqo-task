using API.Test.Repositories.Mocks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace API.Test.Controller
{
    public class ShipControllerTest
    {
        private readonly IShipRepository _shipRepository;

        public ShipControllerTest()
        {
            _shipRepository = new ShipRepositoryMock();
        }

        [Fact]
        public async void ShipController_Create_ReturnsOk()
        {
            Ship ship = new Ship()
            {
                Name = "Ship 4",
                Code = "ABCD-1234-A4",
                Length = 40,
                Width = 40,
            };

            var result = await _shipRepository.Create(ship);

            var shipResult = Assert.IsType<Ship>(result);
            Assert.NotNull(shipResult);
        }

        [Fact]
        public async void ShipController_Update_ReturnsOk()
        {
            Ship Ship = new Ship()
            {
                Id = new Guid("434f62f0-9fd9-44e2-8d16-6f941a3109c5"),
                Name = "Ship 4",
                Code = "ABCD-1234-A4",
                Length = 40,
                Width = 40
            };

            var result = await _shipRepository.Update(Ship);
            var shipResult = Assert.IsType<Ship>(result);
            Assert.NotNull(shipResult);
        }

        [Fact]
        public async void ShipController_Update_ReturnsFalseBecauseItShouldNotFind()
        {
            Ship Ship = new Ship()
            {
                Id = Guid.NewGuid(),
                Name = "Ship 4",
                Code = "ABCD-1234-A5",
                Length = 10,
                Width = 10
            };

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _shipRepository.Update(Ship));
        }

        [Fact]
        public async void ShipController_Delete_ReturnsOK()
        {
            await _shipRepository.Delete(new Guid("434f62f0-9fd9-44e2-8d16-6f941a3109c5"));

            Assert.True(true);
        }

        [Fact]
        public async void ShipController_Delete_ReturnsFalseBecauseIdDoesNotExist()
        {

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _shipRepository.Delete(Guid.NewGuid()));
        }
    }
}
