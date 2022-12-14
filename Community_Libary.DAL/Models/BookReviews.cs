using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.DAL.Models
{
    public class BookReviews
    {
        /*jó*/

        public int Id { get; set; }
        public string BookReview { get; set; }

        public virtual Books Book { get; set; }
        public int? BookId { get; set; }

        public virtual Users Reviewer { get; set; }
        public int? ReviewerId { get; set; }
        public DateTime CreatedTimestamp { get; set; }

    }
}
