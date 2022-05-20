using System.Threading.Tasks;
using JWTBooks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTBooks.Controllers
{
    [Authorize]       //you can't 
    [Route("api/[controller]")]
    [ApiController]
    public class BookController: ControllerBase
    {
        private readonly JWTDBContext _context;
        public BookController(JWTDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var data = await _context.TblBooks.ToListAsync();
            return Ok(data);
        }
    }
}
