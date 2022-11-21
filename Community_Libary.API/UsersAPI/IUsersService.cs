using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.API.UsersAPI
{
    public interface IUsersService
    {
        Task<LoginUserInfoDTO> loginUserAsync(LoginUserDTO user);
        Task registerUserAsync(RegisterUserDTO registerUserDTO);
       
    }
}
