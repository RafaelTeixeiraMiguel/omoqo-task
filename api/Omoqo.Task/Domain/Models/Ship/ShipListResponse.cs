using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ship
{
    public class ShipListResponse
    {
        public long Total { get; set; }
        public List<ShipListItemResponse>? Data { get; set; }
    }
}
