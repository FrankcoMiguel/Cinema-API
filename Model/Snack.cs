using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Snack
    {

        public int SnackId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public double Cost { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

    }
}
