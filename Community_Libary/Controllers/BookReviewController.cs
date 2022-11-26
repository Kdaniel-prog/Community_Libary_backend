using Community_Libary.API.BookReviewAPI;
using Community_Libary.API.BooksAPI;
using Community_Libary.API.UsersAPI;
using Community_Libary.BL.BooksBL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Community_Libary.WEB.Controllers
{
    [Authorize]
    [Route("api/bookreview")]
    [ApiController]
    public class BookReviewController : Controller
    {
        private readonly IBookReviewsService _bookReviewsService;

        public BookReviewController(IBookReviewsService bookReviewsService)
        {
            _bookReviewsService = bookReviewsService;
        }
        // GET: api/bookreview/allreview
        [HttpGet("allreview")]
        public async Task<ActionResult> BookReviews(int bookid, int page, int size)
        {
            try
            {
                return StatusCode(200, await _bookReviewsService.GetAllReviewForBooksAsync(bookid, page-1, size));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // GET: api/bookreview/getSize
        [HttpGet("getSize")]
        public async Task<ActionResult> getSize(int bookid)
        {
            try
            {
                return StatusCode(200, await _bookReviewsService.getSizeAsync(bookid));
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // POST:  api/bookreview/addreview
        [HttpPost("addreview")]
        public async Task<ActionResult> AddReview(BookReviewDTO review)
        {
            try
            {
                await _bookReviewsService.InsertBookReviewAsync(review);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // PUT:  api/bookreview/editreview
        [HttpPut("editreview")]
        public async Task<ActionResult> EditReview(BookReviewDTO review)
        {
            try
            {
                await _bookReviewsService.UpdateBookReviewAsync(review);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // POST:  api/bookreview/Delete/5
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _bookReviewsService.DeleteBookReviewAsync(id);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
