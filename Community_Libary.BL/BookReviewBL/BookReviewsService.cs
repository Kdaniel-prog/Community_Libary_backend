using Community_Libary.API.BookReviewAPI;
using Community_Libary.API.BooksAPI;
using Community_Libary.DAL.DATA;
using Community_Libary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReviews = Community_Libary.DAL.Models.BookReviews;

namespace Community_Libary.BL.BookReviewBL
{
    public class BookReviewsService : IBookReviewsService
    {
        private readonly Community_LibaryDbContext _context;
        public BookReviewsService(Community_LibaryDbContext community_LibaryDbContext)
        {
            _context = community_LibaryDbContext;
        }
        public async Task InsertBookReviewAsync(BookReviewDTO reviewDTO)
        {
            var bookReviewCheck = await _context.BookReviews.Where(bw => bw.BookId.Equals(reviewDTO.bookID) && bw.ReviewerId.Equals(reviewDTO.reviewerID)).FirstOrDefaultAsync();
            if(bookReviewCheck == null)
            {
                BookReviews bookreview = new BookReviews
                {
                    BookReview = reviewDTO.bookReview,
                    BookId = reviewDTO.bookID,
                    ReviewerId = reviewDTO.reviewerID,
                    CreatedTimestamp = DateTime.Now,
                };

                _context.BookReviews.Add(bookreview);
            }

            _context.SaveChanges();
        }
        public async Task UpdateBookReviewAsync(BookReviewDTO book)
        {
            BookReviews item = await _context.BookReviews.Where(bw => bw.ReviewerId == book.reviewerID && bw.BookId == book.bookID).Select(bw => bw).FirstAsync()
            ?? throw new ObjectNotFoundException<BookDTO>(book);
            item.BookReview = book.bookReview;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBookReviewAsync(int id)
        {
            var b = await _context.BookReviews.FindAsync(id)
                    ?? throw new ObjectNotFoundException<Books>(id);
            _context.BookReviews.Remove(b);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AllBookReviewsDTO>> GetAllReviewForBooksAsync(int bookid, int page, int size)
        {
            List<AllBookReviewsDTO> allBookReviews = await _context.BookReviews.Include(b=> b.Reviewer).Where(b => b.BookId.Equals(bookid)).Select(b => new AllBookReviewsDTO
            {
                review = b.BookReview,
                username = b.Reviewer.Username
            }).Skip(page * size).Take(size).ToListAsync();
            return allBookReviews;
        }

        public async Task<int> getSizeAsync(int bookid)
        {
            return await _context.BookReviews.Include(b => b.Reviewer).Where(b => b.BookId.Equals(bookid)).CountAsync();
        }
    }
}
