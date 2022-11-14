using Community_Libary.API.BooksAPI;
using Community_Libary.API.BorrowedAPI;
using Community_Libary.DAL.DATA;
using Community_Libary.DAL.Models;
using Microsoft.EntityFrameworkCore;
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

    }
}
