using StudentManagement.Models;

namespace StudentManagement.Repositries;

public class StudentRepository
{
    private readonly List<Student> students;

    public StudentRepository()
    {
        students = [];
    }

    public void Add(Student newStudent)
    {
        students.Add(newStudent);
    }

    public void Remove(int id)
    {
        students.RemoveAll(x => x.Id == id);
    }

    public bool Update(Student updatedStudent)
    {
        Student? student = students.Find(x => x.Id == updatedStudent.Id);

        if(student == null)
            return false;

        student.Name =  updatedStudent.Name;
        student.Age = updatedStudent.Age;
        student.Grade = updatedStudent.Grade;
        return true;
    }

    public IReadOnlyList<Student> GetStudents()
    {
        return students;
    }

    public Student? GetStudentById(int id)
    {
        return students.FirstOrDefault(x => x.Id == id);
    }
}