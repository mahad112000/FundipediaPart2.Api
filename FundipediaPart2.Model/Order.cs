namespace FundipediaPart2.Model
{
    public class Order
    {

        public bool IsRushOrder { get; set; } 
        public OrderType Type { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsLargeOrder { get; set; }
    }
}
