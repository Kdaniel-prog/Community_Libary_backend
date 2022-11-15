using Community_Libary.API.BooksAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.BookReviewAPI
{
    public interface IBookReviewsService
    {
        Task InsertBookReviewAsync(BookReviewDTO review);
        Task UpdateBookReviewAsync(BookReviewDTO book);
        Task DeleteBookReviewAsync(int id);
        Task<List<AllBookReviewsDTO>> GetAllReviewForBooksAsync(int bookid);
    }
}
