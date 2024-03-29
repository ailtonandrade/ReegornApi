﻿namespace AuthApi.Models
{
    public class CharacterModel
    {
        public long? id { get; set; }
        public string? name { get; set; }
        public long? hp { get; set; }
        public string? acc { get; set; }
        public float? positionX { get; set; }
        public float? positionY { get; set; }
        public float? positionZ { get; set; }
        public float? rotation { get; set; }
        public string? local { get; set; }
        public string? world { get; set; }
        public string? chClass { get; set; }
        public long? level { get; set; }
        public string? gender { get; set; }
        public int? isOnline { get; set; }
    }
}
