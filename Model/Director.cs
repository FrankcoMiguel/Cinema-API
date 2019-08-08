using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Director
    {

        public Director()
        {

           //Film = new HashSet<Film>();

        }

        public int DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ICollection<string> Films { get; set; }
        public string Rating { get; set; }

        //public ICollection<Film> Films { get; set; }

    }
}
