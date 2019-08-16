using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Actor
    {

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Rating { get; set; }
        public ICollection<ActorFilm> Films { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

    }
}

