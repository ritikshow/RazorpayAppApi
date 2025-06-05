namespace RazorpayAppApi.Model
{
    public class Product
    {
        public int Id { get; set; } // ✅ Auto primary key by EF Core
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }

}
