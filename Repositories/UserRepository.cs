using System.Collections.Generic;
using System.Linq;

public static class UserRepository
{
    private static List<User> users = new List<User>();

    public static void Add(User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);
    }

    public static User? GetByUsername(string username)
    {
        return users.FirstOrDefault(u => u.Username == username);
    }


    public static bool ValidateLogin(string username, string password)
    {
        return users.Any(u => u.Username == username && u.Password == password);
    }
}
