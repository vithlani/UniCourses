using System;
using System.Collections.Generic;

namespace UniCourses.Models
{
    public partial class Courses
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CDuration { get; set; }
        public string Description { get; set; }
        public int? UniversityId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual University University { get; set; }
    }
}
