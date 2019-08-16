using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ActorFilm
    {

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }

    }
}
