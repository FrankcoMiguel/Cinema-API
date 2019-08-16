using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Photo
    {

        public int PhotoId { get; set; }
        public string Caption { get; set; }
        public string Url { get; set; }

        public Actor Actor { get; set; }
        public Director Director { get; set; }
        public Employee Employee { get; set; }
        public Film Film { get; set; }
        public Snack Snack { get; set; }


    }
}
