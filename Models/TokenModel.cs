using System;

namespace ReegornApi.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string TokenType { get; set; }
        public int IsNewIpAddress { get; set; }
        public string IpAddress { get; set; }
        public DateTime? Expires { get; set; } = DateTime.Now;

    }
}
