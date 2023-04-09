using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellGYGY_SchoolCase.Models
{
    public class Homework
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public int? StudentId { get; set; }
    }
}
