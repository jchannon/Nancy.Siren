namespace Nancy.Siren.Demo.Model
{
    public class OrderItemViewModel : OrderItem
    {
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public int OrderNumber { get; set; }
    }
}