using Microsoft.EntityFrameworkCore;
using StudentGroup.Context;
using StudentGroup.Models;

StudentGroupDbContext StudentGroupDbContext = new StudentGroupDbContext();

bool IsReady = true;
Commands();
int.TryParse(Console.ReadLine(), out int request);
while (IsReady)
{
    switch (request)
    {
        case 0:
            return;
        case 1:
            CreateStudent();
            break;
        case 2:
            ShowAllStudents();
            break;
        case 3:
            UpdateStudent();
            break;
        case 4:
            DeleteStudent();
            break;
        case 5:
            GetStudentById();
            break;
        case 6:
            CreateGroup();
            break;
        case 7:
            ShowAllGroups();
            break;
        case 8:
            UpdateGroup();
            break;
        case 9:
            DeleteGroup();
            break;
        case 10:
            GetGroupById();
            break;
        case 11:
            Console.Clear();
            break;
        default:
            Console.WriteLine("Enter Valid Option");
            break;
    }
    Commands();
    int.TryParse(Console.ReadLine(), out request);
}

void Commands()
{
    Console.WriteLine("1.Create Student");
    Console.WriteLine("2.ShowAllStudents");
    Console.WriteLine("3.Update Student");
    Console.WriteLine("4.Delete Student");
    Console.WriteLine("5.GetStudentById");
    Console.WriteLine("6.Create Group");
    Console.WriteLine("7.ShowAllGroups");
    Console.WriteLine("8.Update Group");
    Console.WriteLine("9.Delete Group");
    Console.WriteLine("10.GetGroupById");
    Console.WriteLine("11.Clear");
    Console.WriteLine("0.Quit");
}
void CreateStudent()
{
    Console.WriteLine("Enter GroupId:");
    int.TryParse(Console.ReadLine(), out int GroupId);
    Group group = StudentGroupDbContext.Groups.Find(GroupId);
    if (group == null)
    {
        Console.WriteLine("Group is not found!");
        return;
    }
    Student student = new Student();    
    Console.WriteLine("Enter Student's Name:");
    student.Name=Console.ReadLine();
    Console.WriteLine("Enter Student's Surname:");
    student.Surname=Console.ReadLine();
    student.CreatedDate = DateTime.Now; 
    student.UpdateDate = DateTime.UtcNow;
    student.Group = group;
    StudentGroupDbContext.Add(student);
    StudentGroupDbContext.SaveChanges();
}
void CreateGroup()
{
    Console.WriteLine("Enter Group's Name:");
    StudentGroupDbContext.Add(new Group
    {
        Name = Console.ReadLine(),
        CreatedDate= DateTime.Now,  
        UpdateDate= DateTime.UtcNow
    });
    StudentGroupDbContext.SaveChanges();
}
void ShowAllStudents()
{
    List<Student> Students = StudentGroupDbContext.Students.Include(x => x.Group).ToList();
    foreach (Student students in Students)
    {
        Console.Write("Student's Id: ");
        Console.WriteLine(students.Id);
        Console.Write("Student's Name: ");
        Console.WriteLine(students.Name);
        Console.Write("Student's Surname: ");
        Console.WriteLine(students.Surname);
        Console.Write("Student's IsDeleted: ");
        Console.WriteLine(students.IsDeleted);
        Console.Write("Student's CreatedDate: ");
        Console.WriteLine(students.CreatedDate);
        Console.Write("Student's UpdateDate: ");
        Console.WriteLine(students.UpdateDate);
        Console.Write("Student's Group: ");
        Console.WriteLine(students.Group.Name);
         
    }
}
void ShowAllGroups()
{
    List<Group> Groups = StudentGroupDbContext.Groups.ToList();
    foreach (Group groups in Groups)
    {
        Console.Write("Group's Id: ");
        Console.WriteLine(groups.Id);
        Console.Write("Group's Name: ");
        Console.WriteLine(groups.Name);
        Console.Write("Group's IsDeleted: ");
        Console.WriteLine(groups.IsDeleted);
        Console.Write("Group's CreatedDate: ");
        Console.WriteLine(groups.CreatedDate);
        Console.Write("Group's UpdateDate: ");
        Console.WriteLine(groups.UpdateDate);

    }
}
void GetStudentById()
{
    Console.WriteLine("Enter StudentId:");
    int.TryParse(Console.ReadLine(), out int StudentId);
   
    Student student=StudentGroupDbContext.Students.Include(x => x.Group).FirstOrDefault(s => s.Id == StudentId);
    if (student == null)
    {
        Console.WriteLine("Student is not found");
    }
    else
    {
           
        Console.Write("Student's Name: ");
        Console.WriteLine(student.Name);
        Console.Write("Student's Surname: ");
        Console.WriteLine(student.Surname);
        Console.Write("Student's IsDeleted: ");
        Console.WriteLine(student.IsDeleted);
        Console.Write("Student's CreatedDate: ");
        Console.WriteLine(student.CreatedDate);
        Console.Write("Student's UpdateDate: ");
        Console.WriteLine(student.UpdateDate);
        Console.Write("Student's Group: ");
        Console.WriteLine(student.Group.Name);
    }

}
void GetGroupById()
{
    Console.WriteLine("Enter GroupId:");
    int.TryParse(Console.ReadLine(), out int GroupId);
  Group group = StudentGroupDbContext.Groups.FirstOrDefault(s => s.Id == GroupId);
    if (group == null)
    {
        Console.WriteLine("Group is not found");
    }
    else
    {
        Console.Write("Group's Name: ");
        Console.WriteLine(group.Name);
        Console.Write("Group's IsDeleted: ");
        Console.WriteLine(group.IsDeleted);
        Console.Write("Group's CreatedDate: ");
        Console.WriteLine(group.CreatedDate);
        Console.Write("Group's UpdateDate: ");
        Console.WriteLine(group.UpdateDate);
    }
}
void DeleteStudent()
{
    Console.WriteLine("Enter StudentId:");
    int.TryParse(Console.ReadLine(), out int StudentId);
    Student student = StudentGroupDbContext.Students.FirstOrDefault(s => s.Id == StudentId);
    if (student == null)
    {
        Console.WriteLine("Student is not found");
    }
    else
    {
        StudentGroupDbContext.Students.Remove(student);
        StudentGroupDbContext.SaveChanges();    
    }
}
void DeleteGroup(){
    Console.WriteLine("Enter GroupId:");
    int.TryParse(Console.ReadLine(), out int GroupId);
    Group group = StudentGroupDbContext.Groups.FirstOrDefault(s => s.Id == GroupId);
    if (group == null)
    {
        Console.WriteLine("Group is not found");
    }
    else
    {
        StudentGroupDbContext.Groups.Remove(group); 
        StudentGroupDbContext.SaveChanges();
    }
}
void UpdateStudent()
{
    Console.WriteLine("Enter StudentId:");
    int.TryParse(Console.ReadLine(), out int StudentId);
    Student student = StudentGroupDbContext.Students.FirstOrDefault(s => s.Id == StudentId);
    if (student == null)
    {
        Console.WriteLine("Student is not found");
    }
    else
    {
        Console.WriteLine("New Student's Name:");
        student.Name=Console.ReadLine();
        Console.WriteLine("New Student's Surname:");
        student.Surname = Console.ReadLine();
    }

}
void UpdateGroup()
{
    Console.WriteLine("Enter GroupId:");
    int.TryParse(Console.ReadLine(), out int GroupId);
    Group group = StudentGroupDbContext.Groups.FirstOrDefault(s => s.Id == GroupId);
    if (group == null)
    {
        Console.WriteLine("Group is not found");
    }
    else
    {
        Console.WriteLine("New Group's Name:");
        group.Name = Console.ReadLine();
    }

}
