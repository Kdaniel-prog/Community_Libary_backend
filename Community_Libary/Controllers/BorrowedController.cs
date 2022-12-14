using Community_Libary.API.BooksAPI;
using Community_Libary.API.BorrowedAPI;
using Community_Libary.BL.BooksBL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Community_Libary.WEB.Controllers
{
    [Authorize]
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
        // GET: api/borrowed/Books
        [HttpGet("Books")]
        public async Task<ActionResult> BorrowedBooks(int borrowerID, int page, int size)
        {
            try
            {
                return StatusCode(200, await _borrowedService.getBorrowedBooksAsync(borrowerID, page-1, size));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // GET: api/book/mybooksSize/5
        [HttpGet("BooksSize")]
        public async Task<ActionResult> BorrowedBooksSize(int id)
        {
            try
            {
                return StatusCode(200, await _borrowedService.getSizeAsync(id));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _borrowedService.DeleteBorrowBookAsync(id);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
