using WebAPI.Enums;

namespace WebAPI.Helpers;

public static class AppHelper
{
    private static readonly Random Random = new();

    public static int RandomizeNumber(int from = 1, int to = 100) =>
        Random.Next(from, to);

    public static string RandomizeCharacters(int lenght)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var stringChars = new char[lenght];
        for (var i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[Random.Next(chars.Length)];
        }
        return new string(stringChars);
    }
    
    public static ProjectState RandomProjectState()
    {
        var values = Enum.GetValues(typeof(ProjectState));
        var randomBar = (ProjectState)(values.GetValue(Random.Next(values.Length)) ?? throw new InvalidOperationException("Project State not contain such data!"));
        return randomBar;
    }
}