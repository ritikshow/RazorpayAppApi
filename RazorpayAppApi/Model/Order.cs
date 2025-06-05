namespace RazorpayAppApi.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string RazorpayOrderId { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
        public Product? Product { get; set; }
    }

}
