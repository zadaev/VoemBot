using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Telegram.Bot.VoiceMemBot
{
    public class Voices
    {
        public uint Id { get; set; }
        public string Adds { get; set; } = "";
        public string? Name { get; set; }
        public string? Tags { get; set; }
        public string? Performer { get; set; }
        public string? ShouTitle { get; set; }
        public string? Emoji { get; set; }
        public uint Tops { get; set; }

    }
    public class VoemContext : DbContext
    {
        public DbSet<Voices> Voices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = USER-PC\\MSSQLSERVER01; Database = VoemBotdb; Trusted_Connection = True;");
        }

    }
}
