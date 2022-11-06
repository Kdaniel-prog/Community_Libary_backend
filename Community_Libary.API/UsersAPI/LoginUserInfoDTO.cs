using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.UsersAPI
{
    public class LoginUserInfoDTO
    {
        [Required(ErrorMessage = "username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }
    }
}
