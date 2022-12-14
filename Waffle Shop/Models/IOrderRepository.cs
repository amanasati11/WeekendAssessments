using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waffle_Shop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        IEnumerable<OrderDetail> OrderDetail { get; }
    }
}
