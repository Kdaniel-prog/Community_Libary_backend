using Community_Libary.API.UsersAPI;
using Community_Libary.DAL.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.BL.UsersBL
{
    public class UsersService : IUsersService
    {
        private readonly Community_LibaryDbContext _context;

        public UsersService(Community_LibaryDbContext community_LibaryDbContext) 
        { 
            _context = community_LibaryDbContext;
        }

        public async Task<List<UserDTO>> getAllUserAsync()
        {
            return await _context
                .Users
                .Select(u => new UserDTO
                {
                    username = u.Username ?? String.Empty,
                })
                .ToListAsync();
        }
    }
}
