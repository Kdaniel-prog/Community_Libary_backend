using Community_Libary.API.BorrowedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.UserReviewsAPI
{
    public interface IUserReviewsSerivce
    {
        Task<List<GetUsersDTO>> GetAllUserAsync(int id, int page, int size);
        Task<int> getSizeAsync(int bookid);
        Task InsertReviewAsync(ReviewUserDTO review);
        Task<OneUserDTO> GetOneUserAsync(int id);
    }
}
