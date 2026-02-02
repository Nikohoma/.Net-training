namespace flipKey;
public class FlipKey
{
    /// <summary>
    /// Method to validate input and Invert the string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string CleanseAndInvert(string input)
    {
        if (input == null || input.Length < 6)
        {
            return "";
        }
        input = input.ToLower();
        string s = "";
        foreach (char ch in input)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                if ((int)ch % 2 != 0)
                {
                    s += ch;
                }
            }
        }
        s = new string(s.Reverse().ToArray());
        char[] charArray = s.ToCharArray();
        int n = charArray.Length;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                charArray[i] = char.ToUpper(charArray[i]);
            }
        }


        return new string(charArray);
    }
}

/// <summary>
/// Main Class
/// </summary>
public class Program
{
    /// <summary>
    /// Entry Point   
    /// </summary>
    public static void Main()
    {
        FlipKey c = new FlipKey();
        Console.WriteLine(c.CleanseAndInvert("dsfkjd"));
    }
}