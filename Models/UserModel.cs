namespace ReegornApi
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string Username { get; set; }
        public string AccessKey { get; set; }
        public string? Type { get; set; }
        public string? IdSession { get; set; }
        public string? IpAddress { get; set; }
        public int? HasCharactersOnline { get; set; }
        public int IsNewIpAddress { get; set; }
    }
}
