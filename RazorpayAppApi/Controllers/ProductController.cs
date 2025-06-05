using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorpayAppApi.Data;
using RazorpayAppApi.Model;

namespace RazorpayAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Products.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    }

}
