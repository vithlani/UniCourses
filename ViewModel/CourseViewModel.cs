using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniCourses.ViewModel
{
    public class CourseViewModel
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CDuration { get; set; }
        public string Description { get; set; }
        public int? UniversityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Name { get; set; }
    }
}
