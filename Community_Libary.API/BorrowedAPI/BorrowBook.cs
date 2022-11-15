using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.BorrowedAPI
{
    public class BorrowBook
    {
        [Required(ErrorMessage = "Title is required")]
        public int bookID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public int borrowerID { get; set; }
    }
}
