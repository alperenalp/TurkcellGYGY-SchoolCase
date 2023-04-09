using System;
using TurkcellGYGY_SchoolCase.Models;
using TurkcellGYGY_SchoolCase.Services;

StudentService studentService = new StudentService();
TeacherService teacherService = new TeacherService();
ClassroomService classroomService = new ClassroomService();


while (true)
{
    try
    {
        Console.WriteLine("Sınıf İşlemleri->1 | Öğrenci İşlemleri->2 | Öğretmen İşlemleri->3");
        Console.Write("Bir Seçim Yapınız: ");
        int choose = Convert.ToInt32(Console.ReadLine());
        serviceOperations(choose);
    }
    catch (FormatException)
    {
        Console.WriteLine("Lütfen istenen türde değer giriniz!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Bir hatayla karşılaşıldı. Detaylar:");
        Console.WriteLine(ex.Message);
    }

}

void serviceOperations(int choose)
{
    while (choose != 0)
    {
        switch (choose)
        {
            case 1:
                Console.WriteLine("Sınıf Ekle->1 | Sınıf Sil->2 | Tüm Sınıfları Listele->3 | Id ile Sınıf Bul->4 | Sınıf İsmiyle Sınıf Bul->5 | Sınıf Öğretmenini Belirle->6 | Sınıfa Öğrenci Ekle->7 | Önceki Menü->0");
                Console.Write("Bir Seçim Yapınız: ");
                int choosedFunction = Convert.ToInt32(Console.ReadLine());
                choose = choosedFunction == 0 ? 0 : choose;
                classroomOperations(choosedFunction);
                break;
            case 2:
                Console.WriteLine("Öğrenci Ekle->1 | Öğrenci Sil->2 | Tüm Öğrencileri Listele->3 | Id ile Öğrenci Bul->4 | Numara ile Öğrenci Bul->5 | Öğretmene Ödev Gönder->6 | Önceki Menü->0");
                Console.Write("Bir Seçim Yapınız: ");
                choosedFunction = Convert.ToInt32(Console.ReadLine());
                choose = choosedFunction == 0 ? 0 : choose;
                StudentOperations(choosedFunction);
                break;
            case 3:
                Console.WriteLine("Öğretmen Ekle->1 | Öğretmen Sil->2 | Tüm Öğretmenleri Listele->3 | Id ile Öğretmen Bul->4 | Önceki Menü->0");
                Console.Write("Bir Seçim Yapınız: ");
                choosedFunction = Convert.ToInt32(Console.ReadLine());
                choose = choosedFunction == 0 ? 0 : choose;
                TeacherOperations(choosedFunction);
                break;
            default:
                Console.Write("Lütfen Geçerli Bir Seçim Yapınız: ");
                choose = Convert.ToInt32(Console.ReadLine());
                break;
        }
    }
}

void TeacherOperations(int choosedFunction)
{
    switch (choosedFunction)
    {
        case 1:
            addTeacher();
            break;
        case 2:
            deleteTeacherById();
            break;
        case 3:
            showAllTeacher();
            break;
        case 4:
            searchTeacherById();
            break;
        default:
            break;
    }
}

void searchTeacherById()
{
    Console.Write("Aranan öğretmenin id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Teacher teacher = teacherService.GetTeacherById(id);
    if (teacher != null)
    {
        Console.WriteLine($"Öğretmen Id:{teacher.Id}, Öğretmen Adı:{teacher.TeacherFirstName}, Öğretmen Soyadı:{teacher.TeacherLastName}, Öğretmen Sınıfı:{classroomService.GetClassroomNameById((int)teacher.ClassroomId)}");
    }
    else
    {
        Console.WriteLine($"{id} id'li öğretmen bulunamadı.");
    }
}

void showAllTeacher()
{
    List<Teacher> teachers = teacherService.GetAllTeacher().ToList();
    if (teachers.Count() > 0)
    {
        Console.WriteLine("Tüm öğretmenler listeleniyor...");
        foreach (var teacher in teachers)
        {
            Console.Write($"Öğretmen Id:{teacher.Id}, Öğretmen Adı:{teacher.TeacherFirstName}, Öğretmen Soyadı:{teacher.TeacherLastName}, ");
            Console.WriteLine($"Öğretmen Sınıfı:{(teacher.ClassroomId != null ? classroomService.GetClassroomNameById((int)teacher.ClassroomId) : "Atanmamış")}");
        }
    }
    else
    {
        Console.WriteLine("Henüz bir öğretmen eklenmemiş...");
    }
}

void deleteTeacherById()
{
    Console.Write("Silinecek öğretmenin id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Teacher teacher = teacherService.GetTeacherById(id);
    if (teacher != null)
    {
        teacherService.DeleteTeacherById(id);
        if (teacher.ClassroomId != null)
        {
            classroomService.DeleteTeacherInClassroom((int)teacher.ClassroomId);
        }
        Console.WriteLine($"{id} id'li öğretmen silindi.");
    }
    else
    {
        Console.WriteLine($"{id} id'li öğretmen bulunamadı.");
    }
}

void addTeacher()
{
    Console.Write("Öğretmen Id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Öğretmen ismi: ");
    string teacherFirstName = Console.ReadLine();
    Console.Write("Öğretmen soyismi: ");
    string teachertLastName = Console.ReadLine();
    bool result = teacherService.AddTeacher(new Teacher { Id = id, TeacherFirstName = teacherFirstName, TeacherLastName = teachertLastName });
    if (result)
    {
        Console.WriteLine($"{teacherService.GetTeacherNameById(id)} isimli yeni öğretmen eklendi.");
    }
    else
    {
        Console.WriteLine($"{studentService.GetStudentNameById(id)} isimli öğretmen zaten mevcut.");
    }
}

void StudentOperations(int choosedFunction)
{
    switch (choosedFunction)
    {
        case 1:
            addStudent();
            break;
        case 2:
            deleteStudentById();
            break;
        case 3:
            showAllStudent();
            break;
        case 4:
            searchStudentById();
            break;
        case 5:
            searchStudentByNumber();
            break;
        case 6:
            postHomeworkToTeacher();
            break;
        default:
            break;
    }
}

void postHomeworkToTeacher()
{
    Console.Write("Öğrenci id: ");
    int studentId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ödev id: ");
    int homeworkId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ödev Konusu: ");
    string homeworkTitle = Console.ReadLine();
    Console.Write("Ödev Detayları: ");
    string homeworkBody = Console.ReadLine();
    Homework studentHomework = new Homework { Id = homeworkId, Title = homeworkTitle, Body = homeworkBody, StudentId = studentId };
    Student student = studentService.GetStudentById(studentId);
    if (student != null)
    {
        Classroom classroom = classroomService.GetClassroomById((int)student.ClassroomId);
        if (classroom != null)
        {
            Teacher classroomTeacher = classroomService.GetClassroomTeacherByClassroomId((int)classroom.Id);
            if (classroomTeacher != null)
            {
                bool result = studentService.PostHomeworkToTeacher(studentHomework, classroomTeacher);
                if (result)
                {
                    Console.WriteLine($"{homeworkId} id'li ödev başarılı şekilde {teacherService.GetTeacherNameById((int)classroomTeacher.Id)} sınıf öğretmenine gönderildi.");
                }
                else
                {
                    Console.WriteLine($"{homeworkId} id'li ödev zaten {teacherService.GetTeacherNameById((int)classroomTeacher.Id)} sınıf öğretmenine gönderilmiş.");
                }
            }
            else
            {
                Console.WriteLine($"Henüz {classroomService.GetClassroomNameById((int)classroom.Id)} sınıfına sınıf öğretmeni eklenmemiş.");
            }
        }
        else
        {
            Console.WriteLine("Öğrenci henüz bir sınıfa eklenmemiş!");
        }
    }
    else
    {
        Console.WriteLine("Öğrenci bulunamadı.");
    }
}

void searchStudentByNumber()
{
    Console.Write("Aranan öğrencinin numarası: ");
    int studentNumber = Convert.ToInt32(Console.ReadLine());
    Student student = studentService.GetStudentByNumber(studentNumber);
    if (student != null)
    {
        Console.WriteLine($"Öğrenci Id:{student.Id}, Öğrenci Adı:{student.StudentFirstName}, Öğrenci Soyadı:{student.StudentLastName}, Öğrenci Numarası:{student.StudentNumber}, ");
        Console.Write($"Öğrenci Sınıfı:{(student.ClassroomId != null ? classroomService.GetClassroomNameById((int)student.ClassroomId) : "Atanmamış")}");
    }
    else
    {
        Console.WriteLine($"{studentNumber} numaralı öğrenci bulunamadı.");
    }
}

void searchStudentById()
{
    Console.Write("Aranan öğrencinin id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Student student = studentService.GetStudentById(id);
    if (student != null)
    {
        Console.Write($"Öğrenci Id:{student.Id}, Öğrenci Adı:{student.StudentFirstName}, Öğrenci Soyadı:{student.StudentLastName}, Öğrenci Numarası:{student.StudentNumber}, ");
        Console.WriteLine($"Öğrenci Sınıfı:{(student.ClassroomId != null ? classroomService.GetClassroomNameById((int)student.ClassroomId) : "Atanmamış")}");
    }
    else
    {
        Console.WriteLine($"{id} id'li öğrenci bulunamadı.");
    }
}

void showAllStudent()
{
    List<Student> students = studentService.GetAllStudent().ToList();
    if (students.Count() > 0)
    {
        Console.WriteLine("Tüm öğrenciler listeleniyor...");
        foreach (var student in students)
        {
            Console.Write($"Öğrenci Id:{student.Id}, Öğrenci Adı:{student.StudentFirstName}, Öğrenci Soyadı:{student.StudentLastName}, Öğrenci Numarası:{student.StudentNumber}, ");
            Console.WriteLine($"Öğrenci Sınıfı:{(student.ClassroomId != null ? classroomService.GetClassroomNameById((int)student.ClassroomId) : "Atanmamış")}");
        }
    }
    else
    {
        Console.WriteLine("Henüz bir öğrenci eklenmemiş...");
    }
}

void deleteStudentById()
{
    Console.Write("Silinecek öğrencinin id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Student student = studentService.GetStudentById(id);
    if (student != null)
    {
        studentService.DeleteStudentById(id);
        if (student.ClassroomId != null)
        {
            classroomService.DeleteStudentInClassroom((int)student.ClassroomId, student);
        }
        Console.WriteLine($"{id} id'li öğrenci silindi.");
    }
    else
    {
        Console.WriteLine($"{id} id'li öğrenci bulunamadı.");
    }
}

void addStudent()
{
    Console.Write("Öğrenci Id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Öğrenci ismi: ");
    string studentFirstName = Console.ReadLine();
    Console.Write("Öğrenci soyismi: ");
    string studentLastName = Console.ReadLine();
    Console.Write("Öğrenci numarası: ");
    int studentNumber = Convert.ToInt32(Console.ReadLine());
    bool result = studentService.AddStudent(new Student { Id = id, StudentFirstName = studentFirstName, StudentLastName = studentLastName, StudentNumber = studentNumber });
    if (result)
    {
        Console.WriteLine($"{studentService.GetStudentNameById(id)} isimli yeni öğrenci eklendi.");
    }
    else
    {
        if (studentService.GetStudentById(id).StudentNumber == studentNumber)
        {
            Console.WriteLine($"{studentNumber} numaraya sahip {studentService.GetStudentNameByStudentNumber(studentNumber)} isimli öğrenci mevcut.");

        }
        else
        {
            Console.WriteLine($"{id} id'ye sahip {studentService.GetStudentNameById(id)} isimli öğrenci mevcut.");
        }
    }
}

void classroomOperations(int choosedFunction)
{
    switch (choosedFunction)
    {
        case 1:
            addClassroom();
            break;
        case 2:
            deleteClassroomById();
            break;
        case 3:
            showAllClassroom();
            break;
        case 4:
            searchClassroomById();
            break;
        case 5:
            searchClassroomByName();
            break;
        case 6:
            addTeacherToClassroom();
            break;
        case 7:
            addStudentToClassroom();
            break;
        default:
            break;
    }
}

void addStudentToClassroom()
{
    Console.Write("Öğrenci id: ");
    int studentId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Sınıf id: ");
    int classroomId = Convert.ToInt32(Console.ReadLine());
    Student student = studentService.GetStudentById(studentId);
    Classroom classroom = classroomService.GetClassroomById(classroomId);
    if (student == null)
    {
        Console.WriteLine($"{studentId} id'li öğrenci bulunamadı!");
    }
    else if (classroom == null)
    {
        Console.WriteLine($"{classroomId} id'li sınıf bulunamadı!");
    }
    else
    {
        bool result = classroomService.AddStudentToClassroom(student, classroom);
        if (result)
        {
            Console.WriteLine($"{studentService.GetStudentNameById(studentId)} adlı öğrenci başarıyla {classroomService.GetClassroomNameById(classroomId)} sınıfına eklendi.");
        }
        else
        {
            Console.WriteLine("Bu öğrencinin zaten bir sınıfı mevcut.");
        }
    }
}

void addTeacherToClassroom()
{
    Console.Write("Öğretmen id: ");
    int teacherId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Sınıf id: ");
    int classroomId = Convert.ToInt32(Console.ReadLine());
    Teacher teacher = teacherService.GetTeacherById(teacherId);
    Classroom classroom = classroomService.GetClassroomById(classroomId);
    if (teacher == null)
    {
        Console.WriteLine($"{teacherId} id'li öğretmen bulunamadı!");
    }
    else if (classroom == null)
    {
        Console.WriteLine($"{classroomId} id'li sınıf bulunamadı!");
    }
    else
    {
        bool result = classroomService.AddTeacherToClassroom(teacher, classroom);
        if (result)
        {
            Console.WriteLine($"{teacherService.GetTeacherNameById(teacherId)} adlı öğretmen başarıyla {classroomService.GetClassroomNameById(classroomId)} sınıfına eklendi.");
        }
        else
        {
            Console.WriteLine("Bu sınıfta zaten bir sınıf öğretmeni mevcut.");
        }
    }
}

void searchClassroomByName()
{
    Console.Write("Aranan sınıfın ismi: ");
    string classroomName = Console.ReadLine();
    Classroom classroom = classroomService.GetClassroomByName(classroomName);
    if (classroom != null)
    {
        Console.WriteLine($"Sınıf Adı: {classroom.ClassroomName}, Sınıf Öğretmeni: {classroomService.GetClassroomTeacherNameByClassroomId((int)classroom.Id)}, Sınıftaki Öğrenci Sayısı: {classroom.Students.Count()}");
        if (classroom.Students.Count() > 0)
        {
            Console.WriteLine("Sınıftaki Öğrenciler listeleniyor...");
            classroom.Students.ForEach(student => Console.WriteLine($"Öğrenci Id:{student.Id}, Öğrenci Adı:{student.StudentFirstName}, Öğrenci Soyadı:{student.StudentLastName}, Öğrenci Numarası:{student.StudentNumber}"));
        }
    }
    else
    {
        Console.WriteLine($"{classroomName} isimli sınıf bulunamadı.");
    }
}

void searchClassroomById()
{
    Console.Write("Aranan sınıfın id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Classroom classroom = classroomService.GetClassroomById(id);
    if (classroom != null)
    {
        Console.WriteLine($"Sınıf id:{classroom.Id}, Sınıf Adı: {classroom.ClassroomName}, Sınıf Öğretmeni: {classroomService.GetClassroomTeacherNameByClassroomId((int)classroom.Id)}");
        if (classroom.Students.Count() > 0)
        {
            Console.WriteLine("Sınıftaki Öğrenciler listeleniyor...");
            classroom.Students.ForEach(student => Console.WriteLine($"Öğrenci Id:{student.Id}, Öğrenci Adı:{student.StudentFirstName}, Öğrenci Soyadı:{student.StudentLastName}, Öğrenci Numarası:{student.StudentNumber}"));
        }
    }
    else
    {
        Console.WriteLine($"{id} id'li sınıf bulunamadı.");
    }
}

void showAllClassroom()
{
    List<Classroom> classrooms = classroomService.GetAllClassroom().ToList();
    if (classrooms.Count() > 0)
    {
        Console.WriteLine("Tüm sınıflar listeleniyor...");
        classrooms.ForEach(classroom => Console.WriteLine($"Sınıf id:{classroom.Id}, Sınıf Adı: {classroom.ClassroomName}, Sınıf Öğretmeni: {classroomService.GetClassroomTeacherNameByClassroomId((int)classroom.Id)}, Sınıftaki Öğrenci Sayısı: {classroom.Students.ToList().Count()}"));
    }
    else
    {
        Console.WriteLine("Henüz bir sınıf eklenmemiş...");
    }
}

void deleteClassroomById()
{
    Console.Write("Silinecek sınıfın id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    bool result = classroomService.DeleteClassroomById(id);
    if (result)
    {
        Console.WriteLine($"{id}'li sınıf silindi.");
    }
    else
    {
        Console.WriteLine($"{id}'li sınıf bulunamadı.");
    }
}

void addClassroom()
{
    Console.Write("Sınıf Id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Sınıf ismi: ");
    string className = Console.ReadLine();
    bool result = classroomService.AddClassroom(new Classroom { Id = id, ClassroomName = className });
    if (result)
    {
        Console.WriteLine($"{className} isimli yeni sınıf eklendi.");
    }
    else
    {
        Console.WriteLine($"{className} isimli sınıf zaten mevcut.");
    }
}
