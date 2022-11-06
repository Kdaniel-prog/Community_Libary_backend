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
        public virtual Review Review { get; set; }
    }
}
