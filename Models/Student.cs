namespace StudentManagement.Models;

public class Student
{
    public required int Id {get; init;}
    public required string Name {get; set;} = string.Empty;    
    public required int Age {get; set;}
    public required char Grade {get; set;}
}