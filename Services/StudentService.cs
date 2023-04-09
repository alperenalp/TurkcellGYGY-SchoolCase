using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellGYGY_SchoolCase.Abstract;
using TurkcellGYGY_SchoolCase.Models;

namespace TurkcellGYGY_SchoolCase.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new List<Student>();

        public bool AddStudent(Student student)
        {
            foreach (var s in _students)
            {
                if (s.Id == student.Id || s.StudentNumber == student.StudentNumber)
                {
                    return false;
                }
            }
            _students.Add(student);
            return true;
        }

        public void DeleteStudentById(int id)
        {
            _students.Remove(GetStudentById(id));
        }

        public List<Student> GetAllStudent()
        {
            return _students;
        }

        public Student GetStudentById(int id)
        {
            return _students.SingleOrDefault(student => student.Id == id);
        }

        public Student GetStudentByNumber(int studentNumber)
        {
            return _students.SingleOrDefault(student => student.StudentNumber == studentNumber);
        }

        public string GetStudentNameById(int id)
        {
            Student student = GetStudentById(id);
            return student.StudentFirstName + " " + student.StudentLastName;
        }

        public string GetStudentNameByStudentNumber(int studentNumber)
        {
            Student student = GetStudentByNumber(studentNumber);
            return student.StudentFirstName + " " + student.StudentLastName;
        }

        public bool PostHomeworkToTeacher(Homework studentHomework, Teacher teacher)
        {
            foreach (var homework in teacher.Homeworks)
            {
                if (homework.Id == studentHomework.Id)
                {
                    return false;
                }
            }
            teacher.Homeworks.Add(studentHomework);
            return true;
        }
    }
}
