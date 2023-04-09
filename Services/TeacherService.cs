using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellGYGY_SchoolCase.Abstract;
using TurkcellGYGY_SchoolCase.Models;

namespace TurkcellGYGY_SchoolCase.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly List<Teacher> _teachers = new List<Teacher>();

        public bool AddTeacher(Teacher teacher)
        {
            foreach (var t in _teachers)
            {
                if (t.Id == teacher.Id)
                {
                    return false;
                }
            }
            _teachers.Add(teacher);
            return true;
        }

        public void DeleteTeacherById(int id)
        {
            _teachers.Remove(GetTeacherById(id));
        }

        public List<Teacher> GetAllTeacher()
        {
            return _teachers;
        }

        public Teacher GetTeacherById(int id)
        {
            return _teachers.SingleOrDefault(teacher => teacher.Id == id);
        }

        public string GetTeacherNameById(int id)
        {
            Teacher teacher = GetTeacherById(id);
            return teacher.TeacherFirstName + " " + teacher.TeacherLastName;
        }
    }
}
