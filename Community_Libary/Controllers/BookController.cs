using Community_Libary.API.BooksAPI;
using Community_Libary.API.UsersAPI;
using Community_Libary.BL.UsersBL;
using Community_Libary.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Community_Libary.WEB.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : Controller
    {
        private readonly IBooksService _bookService;

        public BookController(IBooksService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/book/mybooks/5
        [HttpGet("mybooks")]
        public async Task<ActionResult> MyBooks(int id, int page, int size)
        {
            try
            {
                return StatusCode(200, await _bookService.GetMyBooksAsync(id, page-1, size));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // GET: api/book/mybooksSize/5
        [HttpGet("mybooksSize")]
        public async Task<ActionResult> MyBooksSize(int id)
        {
            try
            {
                return StatusCode(200, await _bookService.getSizeOfMyBooksAsync(id));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // GET: api/book/allbook/5
        [HttpGet("allbook")]
        public async Task<ActionResult> AllBook(int userid, int page, int size)
        {
            try
            {
                return StatusCode(200, await _bookService.GetBooksAsync(userid, page-1, size));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // GET: api/book/mybooks/5
        [HttpGet("getBookSize")]
        public async Task<ActionResult> getBookSize(int userid)
        {
            try
            {
                return StatusCode(200, await _bookService.getSizeAsync(userid));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [Authorize]
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
