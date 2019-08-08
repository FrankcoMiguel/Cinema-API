using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Actor
    {
        public Actor()
        {

           // Films = new HashSet<Film>();

        }
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ICollection<string> Movies { get; set; }
        public string Rating { get; set; }

        //public ICollection<Starring> Films { get; set; }

    }
}

