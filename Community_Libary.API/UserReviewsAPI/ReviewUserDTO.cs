using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.UserReviewsAPI
{
    public class ReviewUserDTO
    {
        public int ReviewedID { get; set; }
        public int ReviewerID { get; set; }
        public bool IsLiked { get; set; }
    }
}
