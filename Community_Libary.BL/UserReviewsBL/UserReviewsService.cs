using Community_Libary.API.BookReviewAPI;
using Community_Libary.API.UserReviewsAPI;
using Community_Libary.DAL.DATA;
using Community_Libary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.BL.UserReviewsBL
{
    public class UserReviewsService : IUserReviewsSerivce
    {
        private readonly Community_LibaryDbContext _context;
        public UserReviewsService(Community_LibaryDbContext community_LibaryDbContext)
        {
            _context = community_LibaryDbContext;
        }

        public async Task<List<GetUsersDTO>> GetAllUserAsync(int id)
        {
            var users = await _context.UserReviews.Include(u => u.User).Where(u => u.UserID != id).Select(u => new GetUsersDTO
            {
                userId = u.User.Id,
                username = u.User.Username,
                fullName = u.User.FullName,
                like = u.Like,
                dislike = u.Dislike
            }).ToListAsync();
            return users;
        }

        public async Task<OneUserDTO> GetOneUserAsync(int id)
        {
            var users = await _context.UserReviews.Include(u => u.User).Where(u => u.UserID == id).Select(u => new OneUserDTO
            {
                id = u.User.Id,
                Username = u.User.Username,
                Email = u.User.Email,
                Fullname = u.User.FullName,
                Like = u.Like,
                Dislike = u.Dislike
            }).FirstAsync();
            return users;
        }

        public async Task InsertReviewAsync(ReviewUserDTO review)
        {
            var isExit = await _context.Reviews.Where(r => r.ReviewedId.Equals(review.ReviewedID) && r.ReviewerId.Equals(review.ReviewerID)).FirstOrDefaultAsync();
            if(isExit == null)
            {
                var rw = new Review
                {
                    ReviewedId = review.ReviewedID,
                    ReviewerId = review.ReviewerID,
                    IsRecommend = review.IsLiked,
                    Reviewer = await _context.Users.Where(u => u.Id.Equals(review.ReviewerID)).FirstAsync(),
                    Reviewed = await _context.Users.Where(u => u.Id.Equals(review.ReviewedID)).FirstAsync()
                };
                var userRw = await _context.UserReviews.Where(u => u.UserID.Equals(review.ReviewedID)).Select(u => u).FirstAsync();
                if (review.IsLiked)
                {
                    userRw.Like += 1;
                }
                else
                {
                    userRw.Dislike += 1;
                }
                _context.Reviews.Add(rw);
                await _context.SaveChangesAsync();
            }
            else
            {
                if(isExit.IsRecommend != review.IsLiked)
                {
                    var rw = await _context.Reviews.Where(r => r.ReviewedId.Equals(review.ReviewedID) && r.ReviewerId.Equals(review.ReviewerID)).FirstAsync();
                    var userRw = await _context.UserReviews.Where(u => u.UserID.Equals(review.ReviewedID)).Select(u => u).FirstAsync();
                    if (review.IsLiked)
                    {
                        rw.IsRecommend = true;
                        userRw.Like += 1;
                        userRw.Dislike -= 1;
                    }
                    else
                    {
                        userRw.Dislike += 1;
                        userRw.Like -= 1;
                        rw.IsRecommend = false;
                    }
                await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
            }
        }

    }
}
