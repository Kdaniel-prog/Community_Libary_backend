using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.BookReviewAPI
{
    public class BookReviewDTO
    {
        public int? bookID { get; set; }

        public int? reviewerID { get; set; }

        [Required(ErrorMessage = "bookReview is required")]
        public string bookReview { get; set; }
    }
}
