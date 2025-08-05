using System;
class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}
class ConsoleUserPresenter
{
    public User GetUserFromConsole()
    {
        var user = new User();

        Console.Write("User Name: ");
        user.Name = Console.ReadLine();

        Console.Write("User Email: ");
        user.Email = Console.ReadLine();

        return user;
    }

    public void PrintUser(User user)
    {
        Console.WriteLine($"User: {user.Name} <{user.Email}>");
    }
}

class UserFileSaver
{
    private string _filePath = "D:\\PROGRAMS\\VSTUDIOFOLDER\\PROJECTS_FOLDER\\PaternsProjects\\SOLID\\SingleResponsibilityPrinciple\\user.txt";
    public void SaveUser(User user)
    {
        using (var writer = new System.IO.StreamWriter(_filePath, true))
        {
            writer.WriteLine($"Name: {user.Name}, Email: {user.Email}");
        }
    }
}
class Program
{
    static void Main()
    {
        var presenter = new ConsoleUserPresenter();
        var saver = new UserFileSaver();

        User user = presenter.GetUserFromConsole();
        presenter.PrintUser(user);
        saver.SaveUser(user);
    }
}
