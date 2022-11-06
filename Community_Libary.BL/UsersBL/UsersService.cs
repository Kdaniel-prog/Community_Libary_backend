using Community_Libary.API.UsersAPI;
using Community_Libary.DAL.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MovieCatalogApi.Exceptions;
using Community_Libary.DAL.Models;

namespace Community_Libary.BL.UsersBL
{
    public class UsersService : IUsersService
    {
        private readonly Community_LibaryDbContext _context;
        public UsersService(Community_LibaryDbContext community_LibaryDbContext) 
        { 
            _context = community_LibaryDbContext;
        }

        public async Task<List<LoginUserDTO>> getAllUserAsync()
        {
            return await _context
                .Users
                .Select(u => new LoginUserDTO
                {
                    username = u.Username ?? String.Empty,
                })
                .ToListAsync();
        }
        public async Task registerUserAsync(RegisterUserDTO registerUserDTO)
        {
            var conflict = _context.Users.FirstOrDefault(u =>  u.Username == registerUserDTO.username);
            if (conflict != null)
            {
                throw new ConflictException(conflict.Id, nameof(registerUserDTO));
            }
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(registerUserDTO.password);
            byte[] passwordBytes = Encoding.UTF8.GetBytes("Password");

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string encryptedResult = Convert.ToBase64String(bytesEncrypted);

            var newItem = new Users(registerUserDTO.username, encryptedResult, registerUserDTO.Email, registerUserDTO.FullName);
            _context.Users.Add(newItem);
            await _context.SaveChangesAsync();
        }

        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public async Task<LoginUserInfoDTO> loginUserAsync(LoginUserDTO user)
        {
            var userList = await _context.Users.Select(u => u).ToListAsync();
            var userPassword = userList.Where(u => u.Username.ToLower().Equals(user.username.ToLower())).Select(u => u.Password).First();

            if (userPassword == null)
            {
                throw new ArgumentNullException("wrong username");
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes("Password");

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesToBeDecrypted = Convert.FromBase64String(userPassword);
            byte[] passwordBytesdecrypt = Encoding.UTF8.GetBytes("Password");
            passwordBytesdecrypt = SHA256.Create().ComputeHash(passwordBytesdecrypt);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string decryptedResult = Encoding.UTF8.GetString(bytesDecrypted);
            if(decryptedResult != user.password)
            {
                throw new ArgumentException("Wrong password");
            }

            LoginUserInfoDTO result = (LoginUserInfoDTO)userList.Where(u => u.Username.ToLower().Equals(user.username.ToLower())).Select(u => new LoginUserInfoDTO
            {
                username = u.Username,
                Email = u.Email,
                FullName = u.FullName,

            }).First();
            return result;
        }
    }
}
