using System;
using System.Collections.Generic;

namespace UniCourses.Models
{
    public partial class University
    {
        public University()
        {
            Courses = new HashSet<Courses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
    }
}
