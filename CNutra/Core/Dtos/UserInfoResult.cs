﻿namespace backend_dotnet.Core.Dtos.Auth
{
    public class UserInfoResult
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
