using FundipediaPart2.Api.Controllers;
using FundipediaPart2.Domain;
using FundipediaPart2.Model;
using Newtonsoft.Json;
using System.Net;

namespace FundipediaPart2.Test
{
    public class OrderControllerTest
    {
        IOrderService orderService;
        OrderController OrderController;
        public OrderControllerTest()
        {
            orderService = new OrderService();
            OrderController = new OrderController(orderService);
        }
        [Fact]
        public void OrderProcess_success()
        {
            //Arrange
            //closed1
            var largeRepairNewCustomer = new Order { IsLargeOrder = true, Type = OrderType.Repair, IsNewCustomer = true };

            //closed2 
            var orderRushHire = new Order { IsLargeOrder = true, IsRushOrder = true, Type = OrderType.Hire };

            //AuthorisationRequired1
            var largeRepairNotNewCustomer = new Order { IsLargeOrder = true, Type = OrderType.Repair };
            //AuthorisationRequired2
            var orderRushNewCustomer = new Order { IsNewCustomer = true, IsRushOrder = true };
            //Confirmed
            var orderRushNotNewCustomer = new Order { IsNewCustomer = false, IsRushOrder = true };

            //Act
            var resultNewCustomer = orderService.ProcessOrder(largeRepairNewCustomer);
            var resultRushHire = orderService.ProcessOrder(orderRushHire);
            var resultLargeNotNewCustomer = orderService.ProcessOrder(largeRepairNotNewCustomer);
            var resultOrderRushNewCustomer = orderService.ProcessOrder(orderRushNewCustomer);
            var resultOrderRushNotNewCustomer = orderService.ProcessOrder(orderRushNotNewCustomer);

            //Applied in priority order from top to bottom:

            //-Large repair orders for new customers should be closed
            //- Large rush hire orders should always be closed
            //- Large repair orders always require authorisation
            //- All rush orders for new customers always require authorisation
            //- All other orders should be confirmed

            //Assert closed 1 
            Assert.IsType<OrderStatus>(resultNewCustomer.Result);
            Assert.Equal(OrderStatus.Closed, resultNewCustomer.Result);

            //Assert closed 2
            Assert.IsType<OrderStatus>(resultRushHire.Result);
            Assert.Equal(OrderStatus.Closed, resultRushHire.Result);

            //Assert authorisation required 1
            Assert.IsType<OrderStatus>(resultLargeNotNewCustomer.Result);
            Assert.Equal(OrderStatus.AuthorisationRequired, resultLargeNotNewCustomer.Result);

            //Assert authorisation required 2
            Assert.IsType<OrderStatus>(resultOrderRushNewCustomer.Result);
            Assert.Equal(OrderStatus.AuthorisationRequired, resultOrderRushNewCustomer.Result);

            //Assert confirmed
            Assert.IsType<OrderStatus>(resultOrderRushNotNewCustomer.Result);
            Assert.Equal(OrderStatus.Confirmed, resultOrderRushNotNewCustomer.Result);
        }
    }
}