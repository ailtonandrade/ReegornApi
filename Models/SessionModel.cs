using ReegornApi;

namespace AuthApi.Models
{
    public class SessionModel
    {
        public long? id { get; set; }
        public string? local { get; set; }
        public string? world { get; set; }
        public List<CharacterModel>? players { get; set; }
        public List<CreatureModel>? creatures { get; set; }
        public List<ObjectDataModel>? environments { get; set; }
        public List<InfoSessionModel>? infos { get; set; }  
    }
}
