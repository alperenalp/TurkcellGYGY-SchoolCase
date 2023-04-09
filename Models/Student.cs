using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellGYGY_SchoolCase.Models
{
    public class Student
    {
        public int? Id { get; set; }
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public int? StudentNumber { get; set; }
        public int? ClassroomId { get; set; }

    }
}
