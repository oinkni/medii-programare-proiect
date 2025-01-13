using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsTournamentApp.Models;

namespace SportsTournamentApp.Data
{
    public class SportsTournamentAppContext : DbContext
    {
        public SportsTournamentAppContext (DbContextOptions<SportsTournamentAppContext> options)
            : base(options)
        {
        }

        public DbSet<SportsTournamentApp.Models.Team> Team { get; set; } = default!;
        public DbSet<SportsTournamentApp.Models.Player> Player { get; set; } = default!;
        public DbSet<SportsTournamentApp.Models.Tournament> Tournament { get; set; } = default!;
        public DbSet<SportsTournamentApp.Models.Match> Match { get; set; } = default!;
    }
}
