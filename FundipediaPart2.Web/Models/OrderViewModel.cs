using FundipediaPart2.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FundipediaPart2.Web.Models
{
    public class OrderViewModel
    {
        public bool IsRushOrder { get; set; }
        public OrderType Type { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsLargeOrder { get; set; }
        public List<SelectListItem> OrderTypes { get; set; }

    }
}
