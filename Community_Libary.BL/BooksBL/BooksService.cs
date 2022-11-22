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

namespace Community_Libary.BL.BooksBL
{
    public class BooksService : IBooksService
    {
        private readonly Community_LibaryDbContext _context;
        public BooksService(Community_LibaryDbContext community_LibaryDbContext)
        {
            _context = community_LibaryDbContext;
        }

        public async Task DeleteBookAsync(int id)
        {
            var b = await _context.Books
                .Include(b => b.BorrowedBooks.Where(b => b.BookId.Equals(id)))
                .Include(b => b.ReviewBooks.Where(b => b.BookId.Equals(id)))
                .Where(b => b.Id.Equals(id)).FirstAsync()
                    ?? throw new ObjectNotFoundException<Books>(id);
            var borrowBooks = _context.Borrowed.Where(b => b.BookId.Equals(id)).Select(b => b);
            var bookReviews = _context.BookReviews.Where(b => b.BookId.Equals(id)).Select(b => b);
            _context.Remove(b);
            if(borrowBooks != null)
            {
                foreach(var bwBook in borrowBooks)
                {
                    _context.Borrowed.Remove(bwBook);
                }
            }
            if (bookReviews != null)
            {
                foreach (var bookRew in bookReviews)
                {
                    _context.BookReviews.Remove(bookRew);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<AllBook>> GetBooksAsync(int UserId, int page, int size)
        {
            List<AllBook> listOfAvailableBooks =  await _context.Books.Include(b => b.Owner).Where(b => b.OwnerId != UserId).Select(b => new AllBook
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                OwnerID = b.OwnerId,
                OwnerUsername = b.Owner.Username,
                Borrowed = _context.Borrowed.Include(bw => bw.Book).Where(bw => bw.BookId.Equals(b.Id)).First() == null ? false : true,
                borrowerUsername = _context.Borrowed.Include(bw => bw.borrower).Where(bw => bw.BookId.Equals(b.Id)).Select(bw => bw.borrower.Username).First()
            }).Skip(page * size).Take(size).ToListAsync();
            return listOfAvailableBooks;
        }

        public async Task<List<BookDTO>> GetMyBooksAsync(int id, int page, int size)
        {
            var books = await _context.Books.Include(u => u.Owner).Where(b => b.OwnerId.Equals(id)).Select(b => new BookDTO {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                OwnerID = b.OwnerId,
                borrowerUsername = _context.Borrowed.Include(bw => bw.borrower).Where(bw => bw.BookId.Equals(b.Id)).Select(bw => bw.borrower.Username).First()
            }).Skip(page * size).Take(size).ToListAsync() ?? throw new ObjectNotFoundException<BookDTO>();
            return books;
        }

        public async Task<int> getSizeAsync(int UserId)
        {
            return await _context.Books.Include(b => b.Owner).Where(b => b.OwnerId != UserId).CountAsync();
        }

        public async Task<int> getSizeOfMyBooksAsync(int id)
        {
            return await _context.Books.Include(u => u.Owner).Where(b => b.OwnerId.Equals(id)).CountAsync();
        }

        public async Task InsertBookAsync(AddBookDTO book)
        {
            Books newbook = new Books
            {
                Author = book.Author,
                Title = book.Title,
                Owner = await _context.Users.Where(u => u.Id.Equals(book.OwnerID)).Select(u => u).FirstAsync(),
                OwnerId = book.OwnerID
            };

            _context.Books.Add(newbook);
            _context.SaveChanges();
        }

        public async Task UpdateBookAsync(BookDTO book)
        {
            Books item = await _context.Books.FindAsync(book.Id)
            ?? throw new ObjectNotFoundException<BookDTO>(book.Id);
            var conflict = _context.Books.FirstOrDefault(b => b.Id == book.Id);
            if (conflict == null)
                throw new ConflictException(conflict.Id, nameof(BookDTO));
            item.Author = book.Author;
            item.Title = book.Title;
            await _context.SaveChangesAsync();
        }
    }
}
