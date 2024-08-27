using FundipediaPart2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FundipediaPart2.Domain
{
    public class OrderService : IOrderService
    {
        public async Task<OrderStatus> ProcessOrder(Order order)
        {
            if (order.IsLargeOrder && order.Type == OrderType.Repair && order.IsNewCustomer)
                return OrderStatus.Closed;
            if (order.IsLargeOrder && order.IsRushOrder && order.Type == OrderType.Hire)
                return OrderStatus.Closed;
            if ((order.Type == OrderType.Repair && order.IsLargeOrder) || 
                (order.IsRushOrder && order.IsNewCustomer))
                return OrderStatus.AuthorisationRequired;
            
            return OrderStatus.Confirmed;
        }

        //Applied in priority order from top to bottom:

        //-Large repair orders for new customers should be closed
        //- Large rush hire orders should always be closed
        //- Large repair orders always require authorisation
        //- All rush orders for new customers always require authorisation
        //- All other orders should be confirmed

    }
}
