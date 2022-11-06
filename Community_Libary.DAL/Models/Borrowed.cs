using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.DAL.Models
{
    public class Borrowed
    {
        /*jó*/
        public int Id { get; set; }
        public virtual Books Book { get; set; }

        public int? BookId { get; set; }
        public virtual Users borrower { get; set; }
        public int? BorrowerId { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
