using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.DAL.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int? ReviewedId { get; set; }
        public int? ReviewerId { get; set; }

        public virtual Users Reviewer { get; set; }
        public virtual Users Reviewed { get; set; }

    }
}
