﻿namespace Silk.Data.Models
{
    public sealed class BlackListedWord
    {
        public int Id { get; set; }
        public GuildConfig Guild { get; set; }
        public string Word { get; set; }
    }
}