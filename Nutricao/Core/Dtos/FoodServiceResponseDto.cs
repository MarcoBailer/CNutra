﻿using Nutricao.Core.OtherObjects;

namespace Nutricao.Core.Dtos
{
    public class FoodServiceResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Nutrients Food { get; set; }
    }
}