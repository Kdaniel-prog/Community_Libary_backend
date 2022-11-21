using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.UserReviewsAPI
{
    public class OneUserDTO
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
