﻿namespace JwtAuth.Core.Dtos
{
    public class AuthServiceResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Plano { get; set; }
    }
}