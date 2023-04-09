using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellGYGY_SchoolCase.Abstract;
using TurkcellGYGY_SchoolCase.Models;

namespace TurkcellGYGY_SchoolCase.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly List<Classroom> _classrooms = new List<Classroom>();

        public bool AddClassroom(Classroom classroom)
        {
            foreach (var room in _classrooms)
            {
                if (room.Id == classroom.Id || room.ClassroomName.Equals(classroom.ClassroomName))
                {
                    return false;
                }
            }
            _classrooms.Add(classroom);
            return true;
        }

        public bool AddStudentToClassroom(Student student, Classroom classroom)
        {
            if (student.ClassroomId == null)
            {
                classroom.Students.Add(student);
                student.ClassroomId = classroom.Id;
                return true;
            }
            return false;

        }

        public bool AddTeacherToClassroom(Teacher teacher, Classroom classroom)
        {
            if (classroom.ClassTeacher == null)
            {
                classroom.ClassTeacher = teacher;
                teacher.ClassroomId = classroom.Id;
                return true;
            }
            return false;
        }

        public bool DeleteClassroomById(int id)
        {
            Classroom classroom = GetClassroomById(id);
            if (classroom != null)
            {
                _classrooms.Remove(classroom);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteStudentInClassroom(int classroomId, Student student)
        {
            Classroom classroom = GetClassroomById(classroomId);
            if (classroom != null || student != null)
            {
                classroom.Students.Remove(student);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteTeacherInClassroom(int classroomId)
        {
            Classroom classroom = GetClassroomById(classroomId);
            if (classroom != null)
            {
                classroom.ClassTeacher = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Classroom> GetAllClassroom()
        {
            return _classrooms;
        }

        public Classroom GetClassroomById(int id)
        {
            return _classrooms.SingleOrDefault(classroom => classroom.Id == id);
        }

        public Classroom GetClassroomByName(string classroomName)
        {
            return _classrooms.SingleOrDefault(classroom => classroom.ClassroomName.Equals(classroomName));
        }

        public string GetClassroomNameById(int id)
        {
            return GetClassroomById(id).ClassroomName;
        }

        public Teacher GetClassroomTeacherByClassroomId(int classroomId)
        {
            return GetClassroomById(classroomId).ClassTeacher;
        }

        public string GetClassroomTeacherNameByClassroomId(int classroomId)
        {
            Classroom classroom = GetClassroomById(classroomId);
            return classroom.ClassTeacher != null ? classroom.ClassTeacher.TeacherFirstName + " " + classroom.ClassTeacher.TeacherLastName : "Atanmamış";
        }


    }
}
