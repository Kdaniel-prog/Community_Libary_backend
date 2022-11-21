﻿using Community_Libary.API.BooksAPI;
using Community_Libary.API.UserReviewsAPI;
using Community_Libary.API.UsersAPI;
using Community_Libary.BL.BooksBL;
using Microsoft.AspNetCore.Mvc;

namespace Community_Libary.WEB.Controllers
{
    [Route("api/userReviews")]
    [ApiController]
    public class UserReviewsController : Controller
    {
        private readonly IUserReviewsSerivce _userReviewsSerivce;

        public UserReviewsController (IUserReviewsSerivce userReviewsSerivce)
        {
            _userReviewsSerivce = userReviewsSerivce;
        }

        // GET: api/userReviews/allUsers
        [HttpGet("allUsers")]
        public async Task<ActionResult> getAllUsers(int id)
        {
            try
            {
                return StatusCode(200, await _userReviewsSerivce.GetAllUserAsync(id));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // GET: api/userReviews/oneUser
        [HttpGet("oneUser")]
        public async Task<ActionResult> getOneUsers(int id)
        {
            try
            {
                return StatusCode(200, await _userReviewsSerivce.GetOneUserAsync(id));
            }
            catch
            {
                return StatusCode(400);
            }
        }
        // POST:  api/userReviews/addReview
        [HttpPost("addReview")]
        public async Task<ActionResult> AddBook(ReviewUserDTO review)
        {
            try
            {
                await _userReviewsSerivce.InsertReviewAsync(review);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
