public class Leaderboard
{
    public List<(string name, int score)> topK(List<(string name, int score)> players, int k)
    {
        var output = players.OrderByDescending(i => i.score).ThenBy(i => i.name).Take(k);
        return output.ToList();
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Leaderboard l = new Leaderboard();
        List<(string name, int scores)> input = new List<(string name, int scores)> { ("Raj", 80), ("Anu", 95), ("Vikram", 95), ("Meena", 70) };
        
        foreach (var i in l.topK(input, 3))
        {
            Console.Write(i + " ");
        }
    }
}