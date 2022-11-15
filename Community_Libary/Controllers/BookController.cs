using Community_Libary.API.BooksAPI;
using Community_Libary.API.UsersAPI;
using Community_Libary.BL.UsersBL;
using Community_Libary.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Community_Libary.WEB.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBooksService _bookService;

        public BookController(IBooksService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/book/mybooks/5
        [HttpGet("mybooks")]
        public async Task<ActionResult> MyBooks(int id)
        {
            try
            {
                return StatusCode(200, await _bookService.GetMyBooksAsync(id));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // GET: api/book/allbook/5
        [HttpGet("allbook")]
        public async Task<ActionResult> AllBook(int userid)
        {
            try
            {
                return StatusCode(200, await _bookService.GetBooksAsync(userid));
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // POST:  api/book/addBook
        [HttpPost("addBook")]
        public async Task<ActionResult> AddBook(AddBookDTO book)
        {
            try
            {
                await _bookService.InsertBookAsync(book);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        [HttpPut("editBook")]
        public async Task<ActionResult> Edit(BookDTO book)
        {
            try
            {
                await _bookService.UpdateBookAsync(book);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // POST:  api/book/Delete/5
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
