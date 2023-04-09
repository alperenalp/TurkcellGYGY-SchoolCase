using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellGYGY_SchoolCase.Models;

namespace TurkcellGYGY_SchoolCase.Abstract
{
    public interface IClassroomService
    {
        List<Classroom> GetAllClassroom();
        Classroom GetClassroomById(int id);
        Classroom GetClassroomByName(string classroomName);
        bool AddClassroom(Classroom classroom);
        bool DeleteClassroomById(int id);
        bool DeleteStudentInClassroom(int classroomId, Student student);
        bool DeleteTeacherInClassroom(int classroomId);
        bool AddTeacherToClassroom(Teacher teacher, Classroom classroom);
        bool AddStudentToClassroom(Student student, Classroom classroom);
        Teacher GetClassroomTeacherByClassroomId(int classroomId);
        string GetClassroomTeacherNameByClassroomId(int classroomId);


    }
}
