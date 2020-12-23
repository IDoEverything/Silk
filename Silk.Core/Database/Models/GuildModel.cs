﻿#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Silk.Core.Database.Models
{
    public class GuildModel
    {
        [Key] public ulong Id { get; set; }
        
        [Required] 
        [StringLength(5)] 
        public string Prefix { get; set; }

        public GuildConfigModel Configuration { get; set; }
            
        public List<UserModel> Users { get; set; } = new();
    }
}