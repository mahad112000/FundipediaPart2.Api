using FundipediaPart2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundipediaPart2.Domain
{
    public interface IOrderService
    {
        Task<OrderStatus> ProcessOrder(Order order);
    }
}
