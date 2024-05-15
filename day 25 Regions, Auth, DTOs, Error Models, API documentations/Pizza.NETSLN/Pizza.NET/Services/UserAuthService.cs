using Pizza.NET.Models;
using Pizza.NET.Models.DTO;
using Pizza.NET.Repositories;
using Pizza.NET.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Pizza.NET.Services
{
    public class UserAuthService(IRepository<int, Models.User> userRepository) : IUserAuthService
    {
        public async Task<User> Login(UserLoginDTO userLoginDTO)
        {
            var userDB = await userRepository.GetByKey(userLoginDTO.Id) ?? throw new UnauthorizedUserException("Invalid username or password");

            HMACSHA512 hMACSHA = new(userDB.PasswordHashKey);

            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userLoginDTO.Password));

            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);

            if (!isPasswordSame)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }

            return userDB;
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<User> Register(UserRegisterDTO userRegisterDTO)
        {

            try
            {

                HMACSHA512 hMACSHA = new();

                var user = new User()
                {
                    Email = userRegisterDTO.Email,
                    Name = userRegisterDTO.Name,
                    PasswordHashKey = hMACSHA.Key,
                    Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password))
                };

                user = await userRepository.Add(user);

                return user;
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
