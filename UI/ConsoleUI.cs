using System.Xml;
using StudentManagement.Enums;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.UI;

public class ConsoleUI
{
    private readonly StudentService studentService;

    public ConsoleUI()
    {
        studentService = new();
    }

    public void Run()
    {
        while (true)
        {
            ShowMenu();
            if (ReadChoice(out int number))
            {
                if (Enum.IsDefined(typeof(MainMenuOptions), number))
                {
                    MainMenuOptions selectedOption = (MainMenuOptions)number;
                    if (!ExecuteChoice(selectedOption))
                        return;
                }
                else
                {
                    PrintInvalidInput();
                    continue;
                }
            }
            else
            {
                PrintInvalidInput();
                continue;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. View Students");
        Console.WriteLine("3. Search Student");
        Console.WriteLine("4. Update Student");
        Console.WriteLine("5. Delete Student");
        Console.WriteLine("6. Exit");
    }

    private bool ReadChoice(out int numberInput)
    {
        Console.WriteLine();
        Console.Write("Choose an option : ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {

            numberInput = number;
            return true;
        }
        else
        {
            PrintInvalidInput();
            numberInput = -1;
            return false;
        }
    }

    private bool ExecuteChoice(MainMenuOptions selectedOption)
    {
        switch (selectedOption)
        {
            case MainMenuOptions.AddStudent:
                AddStudent();
                return true;
            case MainMenuOptions.ViewStudents:
                ViewStudent();
                return true;
            case MainMenuOptions.SearchStudents:
                SearchStudent();
                return true;
            case MainMenuOptions.UpdateStudent:
                UpdateStudentData();
                return true;
            case MainMenuOptions.RemoveStudent:
                RemoveStudent();
                return true;
            case MainMenuOptions.Exit:
                Console.WriteLine();
                Console.WriteLine("Exiting....");
                return false;
        }

        return true;
    }


    private void PrintInvalidInput()
    {
        Console.WriteLine();
        Console.WriteLine("InvalidInput");
    }
    //Add Student

    private void AddStudent()
    {
        Console.Write("Enter a name : ");
        string? name = Console.ReadLine();
        Console.Write("Enter Age : ");
        string? age = Console.ReadLine();
        Console.Write("Enter Grade : ");
        string? grade = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Name Cannot Be empty!! Try again :");
            name = Console.ReadLine();
        }

        int newAgeInt = 0;

        while (!int.TryParse(age, out newAgeInt))
        {
            Console.Write("Age is Invalid!! Try again:");
            age = Console.ReadLine();
        }
        ;

        while (string.IsNullOrWhiteSpace(grade) || grade.Length != 1)
        {
            Console.Write("Grade is Invalid!! Try again:");
            grade = Console.ReadLine();
        }

        char newGrade = grade[0];

        if (studentService.AddStudent(name, newAgeInt, newGrade))
        {
            Console.WriteLine();
            Console.WriteLine("Student Added SucessFully");
        }
        else
        {
            Console.WriteLine("Failed to add student data");
        }
    }

    private void ViewStudent()
    {
        if (studentService.ViewStudents(out IReadOnlyList<Student> students))
        {
            Console.WriteLine();
            if (students.Count <= 0)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Age}\t{student.Grade}");
            }
        }
        else
        {
            Console.WriteLine("List not Found");
        }
    }

    private void SearchStudent()
    {
        Console.Write("Enter Student ID to search:");
        string? id = Console.ReadLine();
        int idInt = 0;
        if (!int.TryParse(id, out idInt))
        {
            Console.WriteLine();
            Console.WriteLine("Invalid Id. PLease try again!!");
            return;
        }

        if (studentService.SearchStudent(idInt, out Student? student))
        {
            Console.WriteLine("Student Found");
        }
        else
        {
            Console.WriteLine("Student Not Found");
        }
    }

    private void RemoveStudent()
    {
        Console.Write("Enter a student id to remove:");
        string? idInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(idInput))
        {
            Console.WriteLine("Id is Invalid! Try Again Later");
            return;
        }

        if (int.TryParse(idInput, out int id) && studentService.RemoveStudent(id))
        {
            Console.WriteLine("Student Removed Sucessfully");
        }
        else
        {
            Console.WriteLine("Student Failed to remove. No Id Found");
        }
    }

    private void UpdateStudentData()
    {
        Console.Write("Please Enter Student ID:");
        string? idInput = Console.ReadLine();

        if (!int.TryParse(idInput, out int id))
        {
            PrintInvalidInput();
            return;
        }

        if (id <= 0)
        {
            Console.WriteLine("ID is Invalid!!");
            return;
        }

        if (studentService.SearchStudent(id, out Student? student))
        {
            Console.WriteLine();
            Console.WriteLine("Student Found!!");
            Console.WriteLine("Current Data");
            Console.WriteLine();
            Console.WriteLine($"{student?.Id}\t{student?.Name}\t{student?.Age}\t{student?.Grade}");

            Console.WriteLine();
            Console.Write("Enter new Name(Leave empty if you don't want to update:");
            string? newNameInput = Console.ReadLine();
            Console.Write("Enter new Age(Leave empty if you don't want to update:");
            string? newAgeInput = Console.ReadLine();
            Console.Write("Enter new Grade(Leave empty if you don't want to update:");
            string? newGradeInput = Console.ReadLine();

            char grade = (!string.IsNullOrWhiteSpace(newGradeInput) && 
                        newGradeInput.Length == 1) ? newGradeInput[0] : ' ';
            if (studentService.UpdateStudentData(student.Id,newNameInput,newAgeInput,grade))
            {
                Console.WriteLine("Student Data Updated SUcessfully");
            }
            else
            {
                Console.WriteLine("Student Data Failed to update");
            }
        }
        else
        {
            Console.WriteLine("No Student Found");
        }
    }
}