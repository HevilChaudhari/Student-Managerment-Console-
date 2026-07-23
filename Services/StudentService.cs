using System.Diagnostics.Contracts;
using StudentManagement.Models;
using StudentManagement.Repositries;

namespace StudentManagement.Services;

public class StudentService
{
    private readonly StudentRepository studentRepository;

    public StudentService()
    {
        studentRepository = new();
    }

    public bool AddStudent(string name, int age, char grade)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        if (age <= 0)
        {
            return false;
        }
        
        grade = char.ToUpperInvariant(grade);

        if (grade is not ('A' or 'B' or 'C' or 'D' or 'F'))
        {
            return false;
        }

        var students = studentRepository.GetStudents();

        int nextId = students.Count == 0
            ? 1
            : students.Max(s => s.Id) + 1;

        Student newStudent = new Student
        {
            Id = nextId,
            Name = name,
            Age = age,
            Grade = grade
        };

        studentRepository.Add(newStudent);
        return true;
    }

    public bool ViewStudents(out IReadOnlyList<Student> students)
    {
        students = studentRepository.GetStudents();

        if(students == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool SearchStudent(int id, out Student? student)
    {
        student = studentRepository.GetStudentById(id);

        if(student is null)
            return false;
        
        return true;
    }

    public bool RemoveStudent(int id)
    {
        var student  = studentRepository.GetStudentById(id);

        if(student is null)
        {
            return false;
        }

        studentRepository.Remove(student.Id);
        return true;
    }
}