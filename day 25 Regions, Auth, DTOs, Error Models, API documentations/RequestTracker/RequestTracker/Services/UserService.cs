﻿using RequestTracker.Controllers;
using RequestTracker.Exceptions;
using RequestTracker.Models;
using RequestTracker.Models.DTO;
using RequestTracker.Repositories;
using RequestTracker.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace RequestTracker.Services
{

    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Employee> employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var employee = await _employeeRepo.Get(loginDTO.UserId);
                // if(userDB.Status =="Active")
                //{
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(employee);
                return loginReturnDTO;
                // }

                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
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

        public async Task<EmployeeReturnDto> Register(EmployeeRegisterDto employeeDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                employee = new Employee
                {
                    DateOfBirth = employeeDTO.DateOfBirth,
                    Name = employeeDTO.Name,
                    Phone = employeeDTO.Phone,
                    Role = "User",
                    Image = employeeDTO.Image,
                };

                employee = await _employeeRepo.Add(employee);
                user = MapEmployeeUserDTOToUser(employeeDTO, employee.Id);
                user.EmployeeID = employee.Id;
                user = await _userRepo.Add(user);
                //((EmployeeUserDTO)employee).Password = string.Empty;

                return employee.ToEmployeeReturnDto();
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.EmployeeID);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {

            await _employeeRepo.Delete(employee.Id);
        }

        private User MapEmployeeUserDTOToUser(EmployeeRegisterDto employeeDTO, int employeeId)
        {
            User user = new User();
            user.EmployeeID = employeeId;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return user;
        }

        public async Task<bool> IsEnabled(int userId)
        {
            var user = await _userRepo.Get(userId);

            if (user.Status == "Active")
            {
                return true;
            }

            return false;
        }

        public async Task<ActivateEmployeeReturnDto> ActivateUser(ActivateUserDto employeeDetails)
        {
            var user = await _userRepo.Get(employeeDetails.Id);

            if (user == null)
            {
                throw new NoSuchEmployeeException();
            }

            user.Status = "Active";

            user = await _userRepo.Update(user);

            return new ActivateEmployeeReturnDto
            {
                Id = user.EmployeeID,
                Status = user.Status
            };
        }
    }

}
