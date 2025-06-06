namespace RazorpayAppApi.Services
{
    using Razorpay.Api;

    public class RazorpayService
    {
        private readonly string key = "rzp_test_TWvpm6grddGvoo";
        private readonly string secret = "uMUifjgKHKK4UeADMsOZiDaW";

        public string CreateOrder(decimal amount)
        {
            RazorpayClient client = new RazorpayClient(key, secret);

            Dictionary<string, object> options = new Dictionary<string, object>
        {
            { "amount", (int)(amount * 100) },
            { "currency", "INR" },
            { "payment_capture", 1 }
        };

            Order order = client.Order.Create(options);
            return order["id"].ToString();
        }
    }

}
