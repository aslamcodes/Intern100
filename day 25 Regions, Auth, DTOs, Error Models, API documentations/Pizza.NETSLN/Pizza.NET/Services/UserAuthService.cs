using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Models.DTO;
using Pizza.NET.Repositories;
using Pizza.NET.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Pizza.NET.Services
{
    public class UserAuthService(IRepository<int, Models.User> userRepository, ITokenService tokenService, ILogger<UserAuthService> logger) : IUserAuthService
    {
        public async Task<Models.DTO.AuthReturnDto> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var userDB = await userRepository.GetByKey(userLoginDTO.Id) ?? throw new UnauthorizedUserException();

                HMACSHA512 hMACSHA = new(userDB.PasswordHashKey);

                var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userLoginDTO.Password));

                bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);

                if (!isPasswordSame)
                {
                    throw new UnauthorizedUserException();
                }

                var token = tokenService.GenerateToken(userDB);

                logger.LogInformation($"User {userDB.Id} has logged in.");
                return userDB.ToLoginReturnDto(token);
            }
            catch (NoUserFoundException)
            {
                logger.LogError("User not found.");
                throw new UnauthorizedUserException();
            }
            catch (Exception)
            {
                throw;
            }

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

        public async Task<AuthReturnDto> Register(UserRegisterDTO userRegisterDTO)
        {

            try
            {

                HMACSHA512 hMACSHA = new();

                var user = new User()
                {
                    Email = userRegisterDTO.Email,
                    Name = userRegisterDTO.Name,
                    PasswordHashKey = hMACSHA.Key,
                    Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password)),
                    Role = UserRoleEnum.User.ToString()
                };

                user = await userRepository.Add(user);

                var token = tokenService.GenerateToken(user);

                logger.LogInformation($"User {user.Id} has been registered.");
                return user.ToLoginReturnDto(token);
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
