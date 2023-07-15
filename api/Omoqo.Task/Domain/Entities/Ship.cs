namespace Domain.Entities
{
    public class Ship : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}
