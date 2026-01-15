namespace QuestionsCopy;

public class ProgramCopy
{
    #region Ques1
    public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>();

    public SortedDictionary<string,long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string,long> result = new SortedDictionary<string,long>();
        foreach (var i in itemDetails) 
        {
            if (i.Value == soldCount)
            {
                result.Add(i.Key, i.Value); 
            }
        }
        return result;
        if (result == null) { Console.WriteLine("Invalid sold Count"); }
    }
    
    public List<string> FindMinAndMaxSoldItems()
    {
        List<string> result = new List<string>();

        long maxCount = itemDetails.Max(x => x.Value);
        long minCount = itemDetails.Min(x => x.Value);

        foreach(var i in itemDetails)
        {
            if (i.Value == minCount) { result.Add($"Min Sold: {i.Key}"); }
            if (i.Value == maxCount) { result.Add($"Max Sold: {i.Key}"); }
        }
        return result;
    }

    public Dictionary<string,long> sortByCount()
    {
        return itemDetails.OrderBy(x => x.Value).ToDictionary();
    }

    #endregion

    #region Ques2
    public class Movie
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }

        public Movie(string Title, string Artist, string Genre, double Rating)
        {
            this.Title = Title;
            this.Artist = Artist;
            this.Genre = Genre;
            this.Rating = Rating;
        }
    }

    public static List<Movie> MovieList = new List<Movie>();

    public void AddMovie(string MovieDetails)
    {
        string[] parts = MovieDetails.Split(',');
        Movie m = new Movie(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), double.Parse(parts[3].Trim()));
        MovieList.Add(m);       
    }

    public List<Movie> ViewMoviesByGenre(string Genre)
    {
        List<Movie> temp = new List<Movie>();
        foreach (var m in MovieList)
        {
            if(m.Genre == Genre) { temp.Add(m); }
        }

        if (temp.Count == 0) { Console.WriteLine("No movies found in Genre"); }
        return temp;

    }

    public List<Movie> ViewMoviesByRatings()
    {
        return MovieList.OrderBy(x => x.Rating).ToList();
    }
    #endregion


    #region Ques 3
    public static List<int> NumberList = new List<int>();

    public void AddNumber(int Numbers)
    {
        NumberList.Add(Numbers);
    }

    public double GetGPAScored()
    {
        int gpa = 0;
        foreach(var i in NumberList)
        {
            gpa += i * 3;
        }
        gpa = gpa / (NumberList.Count * 3);
        if (NumberList == null) { Console.WriteLine("No Numbers Available"); return -1; }
        return gpa;
    }

    public char GetGradeScored(double gpa)
    {
        if (gpa == 10) { return 'S'; }
        if (gpa < 10 && gpa >= 9) { return 'A'; }
        if (gpa < 9 && gpa >= 8) { return 'B'; }
        if (gpa < 8 && gpa >= 7) { return 'C'; }
        if (gpa < 7 && gpa >= 6) { return 'D'; }
        if (gpa < 6 && gpa >= 5) { return 'E'; }
        else { Console.WriteLine("Invalid GPA"); return 'I'; }
    }
    
    #endregion
}