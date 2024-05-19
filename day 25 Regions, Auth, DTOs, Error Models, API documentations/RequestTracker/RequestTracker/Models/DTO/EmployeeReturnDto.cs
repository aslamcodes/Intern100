﻿namespace RequestTracker.Models.DTO
{
    public class EmployeeReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }

        public string Role { get; set; } = "User";

    }
}
