using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellGYGY_SchoolCase.Models
{
    public class Classroom
    {
        public int? Id { get; set; }
        public string? ClassroomName { get; set;  }
        public Teacher? ClassTeacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
