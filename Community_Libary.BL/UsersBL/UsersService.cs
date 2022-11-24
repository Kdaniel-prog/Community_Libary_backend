using Community_Libary.API.UsersAPI;
using Community_Libary.DAL.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MovieCatalogApi.Exceptions;
using Community_Libary.DAL.Models;

namespace Community_Libary.BL.UsersBL
{
    public class UsersService : IUsersService
    {
        private readonly Community_LibaryDbContext _context;
        private EncryptAndDecrypt enryptAnddecrypt = new EncryptAndDecrypt();
        private JwtAuthenticationManager _jwtAuthenticationManager;
        public UsersService(Community_LibaryDbContext community_LibaryDbContext, JwtAuthenticationManager jwtAuthenticationManager) 
        { 
            _context = community_LibaryDbContext;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        public async Task registerUserAsync(RegisterUserDTO registerUserDTO)
        {
            var conflict = _context.Users.FirstOrDefault(u =>  u.Username == registerUserDTO.username);
            if (conflict != null)
            {
                throw new ConflictException(conflict.Id, nameof(registerUserDTO));
            }
            conflict = _context.Users.FirstOrDefault(u => u.Email == registerUserDTO.Email);
            if (conflict != null)
            {
                throw new ConflictException(conflict.Id, nameof(registerUserDTO));
            }

            string encryptedResult = enryptAnddecrypt.EncryptToString(registerUserDTO.password);

            var newUser = new Users(registerUserDTO.username, encryptedResult, registerUserDTO.Email, registerUserDTO.FullName);
            _context.Add(newUser);
            UserReviews newUserRw = new UserReviews
            {
                Like = 0,
                Dislike = 0,
                User = newUser,
                UserID = newUser.Id
            };
            _context.UserReviews.Add(newUserRw);
            await _context.SaveChangesAsync();
        }

        public async Task<LoginUserInfoDTO> loginUserAsync(LoginUserDTO user)
        {
            var userList = await _context.Users.Select(u => u).ToListAsync();
            var userPassword = userList.Where(u => u.Username.ToLower().Equals(user.username.ToLower())).Select(u => u.Password).First();

            if (userPassword == null)
            {
                throw new ArgumentNullException("wrong username");
            }

            string decryptedResult = enryptAnddecrypt.DecryptToString(userPassword);

            if (decryptedResult != user.password)
            {
                throw new ArgumentException("Wrong password");
            }

            LoginUserInfoDTO result = (LoginUserInfoDTO)userList.Where(u => u.Username.ToLower().Equals(user.username.ToLower())).Select(u => new LoginUserInfoDTO
            {
                id = u.Id,
                username = u.Username,
                Email = u.Email,
                FullName = u.FullName,
                accessToken = _jwtAuthenticationManager.GenerateToken(u.Username)

            }).First();
            return result;
        }
    }
}
