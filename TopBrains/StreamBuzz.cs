namespace StreamBuzz;

/// <summary>
/// CreatorStats Class
/// </summary>
public class CreatorStats
{
    // Properties
    public string? CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }

    // Constructors
    public CreatorStats()
    {

    }
    public CreatorStats(string? creatorName, double[] weeklyLikes)
    {
        CreatorName = creatorName;
        WeeklyLikes = weeklyLikes;
    }

    // List to store creator records
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    /// <summary>
    /// Method to Add Creator in the list
    /// </summary>
    /// <param name="record"></param>
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
        Console.WriteLine("User Registered SuccessFully");
    }

    /// <summary>
    /// Method to retreive top creators based on the likes
    /// </summary>
    /// <param name="records"></param>
    /// <param name="likeThreshold"></param>
    /// <returns></returns>
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach (var creator in records)
        {
            int count = 0;
            foreach (var val in creator.WeeklyLikes)
            {
                if (val >= likeThreshold)
                {
                    count++;
                }
                if (count > 0)
                {
                    result.Add(creator.CreatorName, count);
                }
            }
        }
        return result;
    }

    /// <summary>
    /// Method to calculate average likes
    /// </summary>
    /// <returns></returns>
    public double CalculateAverageLikes()
    {
        int count = 0;
        double total = 0;

        foreach (var creator in EngagementBoard)
        {
            foreach (var val in creator.WeeklyLikes)
            {
                count++;
                total += val;
            }
        }
        return total / count;
    }
}

/// <summary>
/// Main class
/// </summary>
public class Program
{
    // Entry Point
    public static void Main()
    {
        // Instances
        CreatorStats c1 = new CreatorStats("Alice", new double[] { 120, 80, 95, 140, 60 });
        CreatorStats c2 = new CreatorStats("Bob", new double[] { 30, 45, 70, 20, 90 });
        CreatorStats c3 = new CreatorStats("Charlie", new double[] { 200, 180, 220, 160, 190 });

        CreatorStats manager = new CreatorStats();

        // Registering Creators
        manager.RegisterCreator(c1);
        manager.RegisterCreator(c2);
        manager.RegisterCreator(c3);

        // Top Posts
        var topPosts = manager.GetTopPostCounts(CreatorStats.EngagementBoard, 100);

        foreach (var item in topPosts)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }

        // Average Likes
        double avgLikes = manager.CalculateAverageLikes();
        Console.WriteLine(avgLikes);
    }
}
