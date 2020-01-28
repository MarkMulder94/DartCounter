using System;
using System.Collections.Generic;
using System.Text;
using Darts.Lib.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Darts.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<PlayerModel> UserModels { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<TeamModel> Teams { get; set; }

        public DbSet<WantGamePlayerModel> Players { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
