using Community_Libary.API.BooksAPI;
using Community_Libary.API.BorrowedAPI;
using Community_Libary.BL.BooksBL;
using Microsoft.AspNetCore.Mvc;

namespace Community_Libary.WEB.Controllers
{
    [Route("api/borrowed")]
    [ApiController]
    public class BorrowedController : Controller
    {
        private readonly IBorrowedService _borrowedService;

        public BorrowedController(IBorrowedService borrowedService)
        {
            _borrowedService = borrowedService;
        }

        // POST:  api/borrowed/addBook
        [HttpPost("addBorrowed")]
        public async Task<ActionResult> addBorrowed(BorrowBook borrowBook)
        {
            try
            {
                await _borrowedService.BorrowBookAsync(borrowBook);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
