using Domain.Entities;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Ships.Any()) return;

            var ships = new List<Ship>
            {
                new Ship
                {
                    Name = "MSC CANEBERRA",
                    Length = 202.8M,
                    Width = 30.6M,
                    Code = "AAAA-1111-A1",
                },
                new Ship
                {
                    Name = "QUEEN MARY 2",
                    Length = 344.3M,
                    Width = 48.7M,
                    Code = "AAAA-1111-A2",
                },
                new Ship
                {
                    Name = "EVER GIVEN",
                    Length = 399.94M,
                    Width = 59M,
                    Code = "AAAA-1111-A3",
                },
                new Ship
                {
                    Name = "EMMA MAERSK",
                    Length = 397.71M,
                    Width = 56.55M,
                    Code = "AAAA-1111-A4",
                },
                new Ship
                {
                    Name = "HUMANITY 1",
                    Length = 60.7M,
                    Width =  11.4M,
                    Code = "AAAA-1111-A5",
                },
                new Ship
                {
                    Name = "CAP SAN DIEGO",
                    Length = 159.4M,
                    Width =  21.4M,
                    Code = "AAAA-1111-A6",
                },
                new Ship
                {
                    Name = "FRANKFURT EXPRESS",
                    Length = 335.47M,
                    Width =  42.94M,
                    Code = "AAAA-1111-A7",
                },
                new Ship
                {
                    Name = "ANNE SOFIE",
                    Length = 159.8M,
                    Width =  24.34M,
                    Code = "AAAA-1111-A8",
                },
                new Ship
                {
                    Name = "MSC LA SPEZIA",
                    Length = 365.82M,
                    Width = 51.3M,
                    Code = "AAAA-1111-A9",
                },
                new Ship
                {
                    Name = "MSC CADIZ",
                    Length = 270.4M,
                    Width =  40.05M,
                    Code = "AAAA-1111-B1",
                }
            };

            await context.Ships.AddRangeAsync(ships);
            await context.SaveChangesAsync();
        }
    }
}