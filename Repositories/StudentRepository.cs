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

    public void Update(Student updatedStudent)
    {
        Student? student = students.Find(x => x.Id == updatedStudent.Id);

        if(student == null)
            return;

        student.Name = updatedStudent.Name;
        student.Age = updatedStudent.Age;
        student.Grade = updatedStudent.Grade;
    }

    public IReadOnlyList<Student> GetStudents()
    {
        return students;
    }

    public Student? GetStudentById(int id)
    {
        return students.FirstOrDefault(x => x.Id == id);
    }

public bool Contains(int id)
{
    return students.Any(x => x.Id == id);
}
}