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

        public ICollection<Actor> ActorGallery { get; set; }
        public ICollection<Director> DirectorGallery { get; set; }
        public ICollection<Employee> EmployeeGallery { get; set; }
        public ICollection<Film> Billboard { get; set; }
        public ICollection<Snack> Menu { get; set; }


    }
}
