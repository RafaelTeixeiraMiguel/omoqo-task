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
                    Length = 202.8,
                    Width = 30.6,
                    Code = "AAAA-1111-A1",
                },
                new Ship
                {
                    Name = "QUEEN MARY 2",
                    Length = 344.3,
                    Width = 48.7,
                    Code = "AAAA-1111-A2",
                },
                new Ship
                {
                    Name = "EVER GIVEN",
                    Length = 399.94,
                    Width = 59,
                    Code = "AAAA-1111-A3",
                },
                new Ship
                {
                    Name = "EMMA MAERSK",
                    Length = 397.71,
                    Width = 56.55,
                    Code = "AAAA-1111-A4",
                },
                new Ship
                {
                    Name = "HUMANITY 1",
                    Length = 60.7,
                    Width =  11.4,
                    Code = "AAAA-1111-A5",
                },
                new Ship
                {
                    Name = "CAP SAN DIEGO",
                    Length = 159.4,
                    Width =  21.4,
                    Code = "AAAA-1111-A6",
                },
                new Ship
                {
                    Name = "FRANKFURT EXPRESS",
                    Length = 335.47,
                    Width =  42.94,
                    Code = "AAAA-1111-A7",
                },
                new Ship
                {
                    Name = "ANNE SOFIE",
                    Length = 159.8,
                    Width =  24.34,
                    Code = "AAAA-1111-A8",
                },
                new Ship
                {
                    Name = "MSC LA SPEZIA",
                    Length = 365.82,
                    Width = 51.3 ,
                    Code = "AAAA-1111-A9",
                },
                new Ship
                {
                    Name = "MSC CADIZ",
                    Length = 270.4,
                    Width =  40.05,
                    Code = "AAAA-1111-B1",
                }
            };

            await context.Ships.AddRangeAsync(ships);
            await context.SaveChangesAsync();
        }
    }
}