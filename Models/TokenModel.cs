using System;

namespace ReegornApi.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string TokenType { get; set; }
        public DateTime? Expires { get; set; } = DateTime.Now;

    }
}
