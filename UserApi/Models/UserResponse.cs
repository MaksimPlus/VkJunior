﻿namespace UserApi.Models
{
    public class UserResponse
    {
        public List<User> Users { get; set; } = new List<User>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
