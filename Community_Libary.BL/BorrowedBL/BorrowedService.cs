using Community_Libary.API.BooksAPI;
using Community_Libary.API.BorrowedAPI;
using Community_Libary.DAL.DATA;
using Community_Libary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.BL.BorrowedBL
{
    public class BorrowedService : IBorrowedService
    {
        private readonly Community_LibaryDbContext _context;
        public BorrowedService(Community_LibaryDbContext community_LibaryDbContext)
        {
            _context = community_LibaryDbContext;
        }

        public async Task BorrowBookAsync(BorrowBook borrowBook){
            Borrowed borrowed = new Borrowed
            {
                Book = await _context.Books.Select(b => b).Where(b => b.Id.Equals(borrowBook.bookID)).FirstAsync(),
                BookId = borrowBook.bookID,
                borrower = await _context.Users.Select(u => u).Where(u => u.Id.Equals(borrowBook.borrowerID)).FirstAsync(),
                BorrowerId = borrowBook.borrowerID,
                CreatedTimestamp = DateTime.Now,
            };
            _context.Borrowed.Add(borrowed);
            _context.SaveChanges();
        }

        public async Task DeleteBorrowBookAsync(int id)
        {
            var bw = await _context.Borrowed.FindAsync(id)
                ?? throw new ObjectNotFoundException<Borrowed>(id);
            _context.Borrowed.Remove(bw);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BorrowedBookDTO>> getBorrowedBooksAsync(int borrowerID)
        {
            List<BorrowedBookDTO> borrowedBooks = await _context.Borrowed.Include(b => b.Book).Where(b => b.BorrowerId.Equals(borrowerID)).Select(bw => new BorrowedBookDTO
            {
                bookID = bw.BookId,
                title  = bw.Book.Title,
                author = bw.Book.Author,
                ownerUsername = bw.Book.Owner.Username,
                borrowedTime = bw.CreatedTimestamp,
                bookReview = _context.BookReviews.Where(b => b.BookId.Equals(bw.BookId) && b.ReviewerId.Equals(borrowerID)).Select(b => b.BookReview).First(),
                bookReviewID = _context.BookReviews.Where(b => b.BookId.Equals(bw.BookId) && b.ReviewerId.Equals(borrowerID)).Select(b => b.Id).First(),
                borrowedReviewID = bw.Id
            }).ToListAsync();
            return borrowedBooks;
        }
    }
}
