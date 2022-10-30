using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.DAL.Models
{
    public class UserReviews
    {
        public int Id { get; set; }
        public bool IsRecommend { get; set; }
        [ForeignKey("Reviewer"), Column(Order = 0)]
        public virtual Users Reviewer { get; set; }
        [ForeignKey("Reviewed"), Column(Order = 1)]
        public virtual Users Reviewed { get; set; }

    }
}
