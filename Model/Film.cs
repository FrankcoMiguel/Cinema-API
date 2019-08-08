using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Film
    {

        public Film()
        {

           //Actores = new HashSet<Actor>

        }

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }

        //public ICollection<Actor> Actores { get; set; }

    }
}
