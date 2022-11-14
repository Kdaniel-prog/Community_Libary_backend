using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.DAL.Models
{
    public class Books
    {
        /*jó*/
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public virtual Users Owner {get; set;}
        public int OwnerId { get; set; }

        [InverseProperty("Book")]
        public virtual ICollection<BookReviews> ReviewBooks { get; set; }
        [InverseProperty("Book")]
        public virtual ICollection<Borrowed> BorrowedBooks { get; set; }
    }
}
