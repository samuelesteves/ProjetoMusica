using Microsoft.EntityFrameworkCore;
using projetoMusica.Models;

namespace projetoMusica.Data
{
    public class Context
    {
        public class AppCont : DbContext 
        {
            public AppCont (DbContextOptions<AppCont> options) : base(options)
            {

            }

            public DbSet<Music> musics { get; set; } 

            public DbSet<Artist> artists { get; set; }

        }

    }
}
