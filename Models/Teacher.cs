using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellGYGY_SchoolCase.Models
{
    public class Teacher
    {
        public int? Id { get; set; }
        public string? TeacherFirstName { get; set; }
        public string? TeacherLastName { get; set; }
        public List<Homework> Homeworks { get; set; } = new List<Homework>();
        public int? ClassroomId { get; set; }
    }
}
