﻿namespace RequestTracker.Models.DTO
{
    public class LoginReturnDTO
    {
        public int EmployeeID { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}