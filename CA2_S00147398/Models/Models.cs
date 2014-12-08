using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2_S00147398.Models
{
    class MovieDbInitialiser : DropCreateDatabaseAlways<MovieDb>
    {
        protected override void Seed(MovieDb context)
        {
            //seeds the database
            var seedMovieData = new List<Movies>
            {
             //Creats a movie with a name and description and creates the actors in the movie with a name and screen name and links them
             new Movies() { MovieName="Oceans 11", Description="Danny Ocean and his eleven accomplices plan to rob three Las Vegas casinos simultaneously.",
             
                Actors = new List<Actors>()
             {
                 new Actors() { ActorName="Matt Damon", 
                               ScreenName="Linus Caldwell"},
                 new Actors() { ActorName="George Clooney", 
                                ScreenName="Danny Ocean"},
                 new Actors() { ActorName="Brad Pitt", 
                                ScreenName="Rusty Ryan"},
                 new Actors() { ActorName="Bernie Mac", 
                                ScreenName="Frank Catton"},
                 new Actors() { ActorName="Elliott Gould", 
                                ScreenName="Reuben Tishkoff"}
             }

            },
             //Creats a movie with a name and description and creates the actors in the movie with a name and screen name and links them
            new Movies() { MovieName="Oceans 12", Description="Daniel Ocean recruits one more team member so he can pull off three major European heists in this sequel to Ocean's 11.",
             
                Actors = new List<Actors>()
             {
                 new Actors() { ActorName="Matt Damon", 
                               ScreenName="Linus Caldwell"},
                 new Actors() { ActorName="George Clooney", 
                                ScreenName="Danny Ocean"},
                 new Actors() { ActorName="Brad Pitt", 
                                ScreenName="Rusty Ryan"},
                 new Actors() { ActorName="Julia Roberts", 
                                ScreenName="Tess Ocean"},
                 new Actors() { ActorName="Catherine Zeta-Jones", 
                                ScreenName="Isabel Lahiri"}
             }

            },
            //Creats a movie with a name and description and creates the actors in the movie with a name and screen name and links them
            new Movies() { MovieName="Oceans 13", Description="Danny Ocean rounds up the boys for a third heist, after casino owner Willy Bank double-crosses one of the original eleven, Reuben Tishkoff.",
             
                Actors = new List<Actors>()
             {
                 new Actors() { ActorName="Matt Damon", 
                               ScreenName="Linus Caldwell"},
                 new Actors() { ActorName="George Clooney", 
                                ScreenName="Danny Ocean"},
                 new Actors() { ActorName="Brad Pitt", 
                                ScreenName="Rusty Ryan"},
                 new Actors() { ActorName="Julia Roberts", 
                                ScreenName="Reuben Tishkoff"},
                 new Actors() { ActorName="Al Pacino", 
                                ScreenName="Willy Bank"}
             }

            },
            //Creats a movie with a name and description and creates the actors in the movie with a name and screen name and links them
            new Movies() { MovieName="The Bourne Identity", Description="A man is picked up by a fishing boat, bullet-riddled and suffering from amnesia, before racing to elude assassins and regain his memory.",
             
                Actors = new List<Actors>()
             {
                 new Actors() { ActorName="Matt Damon", 
                               ScreenName="Jason Bourne"},
                 new Actors() { ActorName="Brian Cox", 
                                ScreenName="Ward Abbott"},
                 new Actors() { ActorName="Chris Cooper", 
                                ScreenName="Conklin"},
                 new Actors() { ActorName="Franka Potente", 
                                ScreenName="Marie"},
                 new Actors() { ActorName="Clive Owen", 
                                ScreenName="The Professor"}
             }

            },
            //Creats a movie with a name and description and creates the actors in the movie with a name and screen name and links them
            new Movies() { MovieName="The Bourne Supremacy", Description="When Jason Bourne is framed for a CIA operation gone awry, he is forced to resume his former life as a trained assassin to survive.",
                
                Actors = new List<Actors>()
            {
                 new Actors() { ActorName="Matt Damon", 
                                ScreenName="Jason Bourne"},
                 new Actors() { ActorName="Brian Cox", 
                                ScreenName="Ward Abbott"},
                 new Actors() { ActorName="Julia Stiles", 
                                ScreenName="Nicky Parsons"},
                 new Actors() { ActorName="Franka Potente", 
                                ScreenName="Marie Kreutz"},
                 new Actors() { ActorName="Karl Urban", 
                                ScreenName="Kirill"}
            }},
            //Creats a movie with a name and description and creates the actors in the movie with a name and screen name and links them
            new Movies() { MovieName="The Bourne Ultimatum", Description="Jason Bourne dodges a ruthless CIA official and his agents from a new assassination program while searching for the origins of his life as a trained killer.",
                
                Actors = new List<Actors>()
            {
                 new Actors() { ActorName="Matt Damon", 
                                ScreenName="Jason Bourne"},
                 new Actors() { ActorName="Brian Cox", 
                                ScreenName="Ward Abbott"},
                 new Actors() { ActorName="Julia Stiles", 
                                ScreenName="Nicky Parsons"},
                 new Actors() { ActorName="Franka Potente", 
                                ScreenName="Marie Kreutz"},
                 new Actors() { ActorName="David Strathairn", 
                                ScreenName="Noah Vosen"}
            }}

            };
            seedMovieData.ForEach(mov => context.Movie.Add(mov));
            //Saves changes
            context.SaveChanges();
            base.Seed(context);
        }
    }

    class MovieDb : DbContext
    {
        public DbSet<Movies> Movie { get; set; }
        public DbSet<Actors> Actor { get; set; }
        public MovieDb()
            : base("MovieDb")
        { }
    }
    //Creates the class for movies, setting the name, ID, error message and holds a collection of actors
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Must enter a movie Name with a minimum of 2 characters.", MinimumLength = 2)]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }
        [Required]
        [Display(Name = "Synopsis"), StringLength(200)]
        public string Description { get; set; }

        public ICollection<Actors> Actors { get; set; }
    }
    //Creates the class for movies, setting the name, screen name, ID, error message and holds a movieid
    public class Actors
    {
        [Key]
        public int ActorId { get; set; }
        public int MovieID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Must enter an Actors Name with minimum {0} characters.", MinimumLength = 3)]
        [Display(Name = "Actors Name")]
        public string ActorName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Must enter an actors Screen Name with minimum {0} characters.", MinimumLength = 3)]
        [Display(Name = "Screen Name")]
        public string ScreenName { get; set; }
    }
}