using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Orders.Commands.Create
{
    public class BasketDto
    {
        public string Email { get; set; }
        public List<BasketItemDto> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}
