using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ship
{
    public class ShipUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public string Code { get; set; } = string.Empty;
    }
}
