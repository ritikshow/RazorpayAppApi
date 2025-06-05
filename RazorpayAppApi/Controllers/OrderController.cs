using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RazorpayAppApi.Data;
using RazorpayAppApi.Model;
using RazorpayAppApi.Services;

namespace RazorpayAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly RazorpayService _razorpayService;

        public OrderController(AppDbContext context, RazorpayService razorpayService)
        {
            _context = context;
            _razorpayService = razorpayService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var product = await _context.Products.FindAsync(order.ProductId);
            if (product == null) return NotFound();

            order.Amount = product.Price;
            order.RazorpayOrderId = _razorpayService.CreateOrder(product.Price);
            order.PaymentStatus = "Pending";

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> UpdatePaymentStatus(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return NotFound();

            order.PaymentStatus = status;
            await _context.SaveChangesAsync();
            return Ok(order);
        }
    }

}
