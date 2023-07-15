namespace Domain.Models.Ship
{
    public class ShipListRequest
    {
        public int Skip { get; set; } = 0;
        public int Limit { get; set; } = 10;

        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
