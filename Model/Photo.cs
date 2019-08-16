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

        public ICollection<Actor> ActorGallery { get; }
        public ICollection<Director> DirectorGallery { get; }
        public ICollection<Employee> EmployeeGallery { get; }
        public ICollection<Film> Billboard { get; }
        public ICollection<Snack> Menu { get; }


    }
}
