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
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Text { get; set; }

        public virtual Users user { get; set; }

        public DateTime CreatedTimestamp { get; set; }

    }
}
