using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.DAL.Models
{
    public class Users 
    {
        /*jó*/

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public Users(string username, string password, string email, string fullName)
        {
            Username = username;
            Password = password;
            Email = email;
            FullName = fullName;
        }
        [InverseProperty("Borrower")]
        public virtual ICollection<Borrowed> Borrowers { get; set; }
        [InverseProperty("Reviewer")]
        public virtual ICollection<Review> Reviewers { get; set; }
        [InverseProperty("Reviewed")]
        public virtual ICollection<Review> Revieweds { get; set; }
        [InverseProperty("Reviewer")]
        public virtual ICollection<BookReviews> BookReviews { get; set; }
    }
}
