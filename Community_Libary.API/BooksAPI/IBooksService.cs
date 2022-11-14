﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.BooksAPI
{
    public interface IBooksService
    {
        Task<List<AllBook>> GetBooksAsync(int UserId);
        Task UpdateBookAsync(BookDTO book);
        Task InsertBookAsync(AddBookDTO book);
        Task DeleteBookAsync(int id);
        Task<List<BookDTO>> GetMyBooksAsync(int userid);
    }
}
