using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.UserReviewsAPI
{
    public class GetUsersDTO
    {
        public int userId { get; set; }
        public string username {get;set;}
        public string fullName {get;set;}
        public int like { get;set;}
        public int dislike { get; set; }
    }
}
