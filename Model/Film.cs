using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Film
    {

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Duration { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public ICollection<ActorFilm> Actores { get; set; }
        
    }
}
