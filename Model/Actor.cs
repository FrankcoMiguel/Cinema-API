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
        public virtual int ActorId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual char Gender { get; set; }
        public virtual string Rating { get; set; }

        //public ICollection<Starring> Films { get; set; }

    }
}

