using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellGYGY_SchoolCase.Models;

namespace TurkcellGYGY_SchoolCase.Abstract
{
    public interface IStudentService
    {
        List<Student> GetAllStudent();
        Student GetStudentById(int id);
        Student GetStudentByNumber(int studentNumber);
        bool AddStudent(Student student);
        void DeleteStudentById(int id);
        string GetStudentNameById(int id);
        string GetStudentNameByStudentNumber(int studentNumber);
        bool PostHomeworkToTeacher(Homework homework, Teacher teacher);
    }
}
