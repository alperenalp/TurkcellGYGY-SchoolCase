using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellGYGY_SchoolCase.Models;

namespace TurkcellGYGY_SchoolCase.Abstract
{
    public interface ITeacherService
    {
        List<Teacher> GetAllTeacher();
        Teacher GetTeacherById(int id);
        bool AddTeacher(Teacher teacher);
        void DeleteTeacherById(int id);
        string GetTeacherNameById(int id);
    }
}
