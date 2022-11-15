using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.BorrowedAPI
{
    public class BorrowedBookDTO
    {
        [Required(ErrorMessage = "bookID is required")]
        public int? bookID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string author { get; set; }

        [Required(ErrorMessage = "OwnerUsername is required")]
        public string ownerUsername { get; set; }

        [Required(ErrorMessage = "borrowedTime is required")]
        public DateTime borrowedTime { get; set; }

        public string? bookReview { get; set; }

        public int? bookReviewID { get; set; }

        public int? borrowedReviewID { get; set; }

    }
}
