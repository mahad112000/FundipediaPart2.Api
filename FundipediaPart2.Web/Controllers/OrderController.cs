using FundipediaPart2.Model;
using FundipediaPart2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FundipediaPart2.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var orderModel = new OrderViewModel();
            orderModel.OrderTypes = new List<SelectListItem>();
            foreach (string type in Enum.GetNames(typeof(OrderType)))
            {
                var item = new SelectListItem
                {
                    Text = type,
                    Value = type
                };
                orderModel.OrderTypes.Add(item);
            }
            return View(orderModel);
        }

        

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
