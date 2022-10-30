using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.DAL.Models
{
    public class Borrowed
    {
        public int Id { get; set; }
        public virtual Books Book { get; set; }
        public virtual Users Borrower { get; set; }

        public DateTime CreatedTimestamp { get; set; }
    }
}
