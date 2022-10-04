using Microsoft.Extensions.DependencyInjection;
using projetoMusica.Models;
using static projetoMusica.Data.Context;

namespace projetoMusica.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCont>();
                context.Database.EnsureCreated();

                if (!context.musics.Any())
                {
                    context.musics.AddRange(new List<Music>()
                    {
                        new Music()
                        {
                            musicName = "Obey",
                            Artist = "Bring me The Horizon",
                            Genre = "Metal",
                            Explicit = true,
                            releaseDate = "2020"
                        },
                        new Music()
                        {
                            musicName = "Glimpse of Us",
                            Artist = "Joji",
                            Genre = "Alternative/Indie",
                            Explicit = false,
                            releaseDate = "2022"
                        },
                        new Music()
                        {
                            musicName = "A Noite",
                            Artist = "Tiê",
                            Genre = "Indie Pop",
                            Explicit = false,
                            releaseDate = "2014"
                        },
                        new Music()
                        {
                            musicName = "Throne",
                            Artist = "Bring me The Horizon",
                            Genre = "Metal",
                            Explicit = false,
                            releaseDate = "2015"
                        },
                        new Music()
                        {
                            musicName = "SLOW DANCING IN THE DARK",
                            Artist = "Joji",
                            Genre = "R&B/Soul",
                            Explicit = true,
                            releaseDate = "2018"
                        }
                    });

                   

                    context.SaveChanges();

                    

                    
                }

                if (!context.artists.Any())
                {
                    context.artists.AddRange(new List<Artist>()
                        {
                            new Artist()
                            {
                                artistName= "Joji",
                                mainInstrument = "Vocal",
                                mainGenre = "R/B",
                                born = "1992",
                                group = null
                            },
                            new Artist()
                            {
                                artistName= "Oliver Sykes",
                                mainInstrument = "Vocal",
                                mainGenre = "Metalcore",
                                born = "1986",
                                group = "Bring Me the Horizon"
                            },
                            new Artist()
                            {
                                artistName= "Jordan Fish",
                                mainInstrument = "Eletronic Keyboard",
                                mainGenre = "Metalcore",
                                born = "1986",
                                group = "Bring Me the Horizon"
                            },
                            new Artist()
                            {
                                artistName= "Tiê Gasparinetti Biral",
                                mainInstrument = "Vocal",
                                mainGenre = "MPB",
                                born = "1980",
                                group = null
                            },
                        });

                    context.SaveChanges();
                }
            }
            
        }
    }
}
