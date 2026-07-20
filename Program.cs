using StudentManagement.Enums;
using StudentManagement.Services;

StudentService studentService = new();

Console.WriteLine("======================================");
Console.WriteLine("Student Management System");
Console.WriteLine("======================================");



while (true)
{
    Console.WriteLine();
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View Students");
    Console.WriteLine("3. Search Student");
    Console.WriteLine("4. Update Student");
    Console.WriteLine("5. Delete Student");
    Console.WriteLine("6. Exit");
    Console.WriteLine();
    Console.Write("Choose an option : ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int number))
    {
        if (Enum.IsDefined(typeof(MainMenuOptions), number))
        {
            MainMenuOptions selectedOption = (MainMenuOptions)number;
            switch (selectedOption)
            {
                case MainMenuOptions.AddStudent:
                    // if(studentService.AddStudent())
                    continue;
                case MainMenuOptions.ViewStudents:
                    continue;
                case MainMenuOptions.SearchStudents:
                    continue;
                case MainMenuOptions.UpdateStudent:
                    continue;
                case MainMenuOptions.DeleteStudent:
                    continue;
                case MainMenuOptions.Exit:
                    Console.WriteLine();
                    Console.WriteLine("Exiting....");
                    return;
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("InvalidInput");
            continue;
        }

    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("InvalidInput");
        continue;
    }
}


// static (string,int,char) GetStudentDataInput()
// {
    
// }
