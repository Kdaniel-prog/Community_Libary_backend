using Community_Libary.API.BooksAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.BorrowedAPI
{
    public interface IBorrowedService
    {
        Task BorrowBookAsync(BorrowBook borrowBook);

    }
}
