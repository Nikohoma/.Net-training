using System;
using System.Collections;

namespace Questions;

public class Program
{
    #region Ques 1
    public static SortedDictionary<string, long> ItemDetails = new SortedDictionary<string,long>();

    /// <summary>
    /// Item Details Operations
    /// </summary>
    /// <param name="i"></param>
    /// <param name="l"></param>
    public void AddItems(string i , long l)
    {
        ItemDetails.Add(i, l);
    }

    public SortedDictionary<string, long> GetItems()
    {
        return ItemDetails;
    }

    /// <summary>
    /// Methods
    /// </summary>
    /// <param name="soldCount"></param>
    /// <returns></returns>
    public SortedDictionary<string,long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string, long> result = new SortedDictionary<string, long>();
        foreach(var item in ItemDetails)
        {
            if(item.Value == soldCount) { result.Add(item.Key,item.Value); return result; }
            
        }
        Console.WriteLine("Invalid Sold Count");
        return result;
    }

    /// <summary>
    /// Method to find min and max sold items
    /// </summary>
    /// <returns></returns>
    public List<string> FindMinAndMaxSoldItems()
    {
        List<string> result = new List<string>();
        long MinCount = ItemDetails.Min(x => x.Value);
        long MaxCount = ItemDetails.Max(x => x.Value);

        foreach (var item in ItemDetails)
        {
            if (item.Value == MinCount) { result.Add(item.Key); }
            if (item.Value == MaxCount) {  result.Add(item.Key); }
        }
        return result;
    }

    /// <summary>
    /// Method to return a Sorted Dictionary
    /// </summary>
    /// <returns></returns>
    public Dictionary<string,long> SortByCount()
    {
        return ItemDetails.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    }

    #endregion

    #region Ques 2

    /// <summary>
    /// Movie Type for Ques 2
    /// </summary>
    public class Movie
    {
        #region Properties
        public string Title; public string Artist; public string Genre; public int Ratings;
        #endregion

        public Movie(string Title, string Artist, string Genre, int Ratings)
        {
            this.Title = Title;
            this.Artist = Artist;
            this.Genre = Genre;
            this.Ratings = Ratings;
        }
    }
    /// <summary>
    /// Store Movie Objects
    /// </summary>

    public static List<Movie> MovieList = new List<Movie>();

    /// <summary>
    /// Method to add Movie in MovieList
    /// </summary>
    /// <param name="MovieDetails"></param>
    public void AddMovie(string MovieDetails)
    {
        string[] MovieObjects = MovieDetails.Split(',');
        Movie movie = new Movie(MovieObjects[0].Trim(), MovieObjects[1].Trim(), MovieObjects[2].Trim(), int.Parse(MovieObjects[3].Trim()));
        MovieList.Add(movie);
    }

    /// <summary>
    /// Method to get movie from MovieList
    /// </summary>
    /// <returns></returns>
    public List<Movie> GetMovie() { return MovieList; }

    /// <summary>
    /// Method to Get Movie filtered by genre
    /// </summary>
    /// <param name="Genre"></param>
    /// <returns></returns>
    public List<Movie> ViewMoviesByGenre(string Genre)
    {
        List<Movie> movies = new List<Movie>();

        foreach (var m in MovieList)
        {
            if (m.Genre == Genre.Trim()) { movies.Add(m); }
        }
        if (movies.Count == 0) { Console.WriteLine($"\nNo Movies found in Genre: {Genre}"); return movies; }
        return movies;
    }

    /// <summary>
    /// Method to get Movie ordered by ratings
    /// </summary>
    /// <returns></returns>
    public List<Movie> ViewMoviesByRating()
    {
        return MovieList.OrderBy(m => m.Ratings).ToList();
    }
    #endregion

    #region Ques 3

    /// <summary>
    /// List to store all the numbers
    /// </summary>
    public List<int> NumberList = new List<int>(); 

    /// <summary>
    /// Method to add Numbers in the NumberList
    /// </summary>
    /// <param name="Numbers"></param>
    public void AddNumbers(int Numbers)
    {
        NumberList.Add(Numbers);
    }

    /// <summary>
    /// Method to find GPA calculated by numbers
    /// </summary>
    /// <returns></returns>
    public double GetGPAScored()
    {
        double gpa = 0;
        if (NumberList == null) { Console.WriteLine("No Numbers Available"); return -1; }

        foreach (var n in NumberList)
        {
            gpa += n * 3;
        }
        gpa = gpa / (NumberList.Count * 3);
        return gpa;
    }

    /// <summary>
    /// Method to calculate Grade from the GPA
    /// </summary>
    /// <param name="gpa"></param>
    /// <returns></returns>
    public char GetGradeScored(double gpa)
    {
        if (gpa == 10) { return 'S'; }
        if (gpa >= 9 && gpa < 10) { return 'A'; }
        if (gpa >= 8 && gpa < 9 ) { return 'B'; }
        if (gpa >= 7 && gpa < 8) { return 'C'; }
        if (gpa >= 6 && gpa < 7) { return 'D'; }
        if (gpa >= 5 && gpa < 6) { return 'E'; }
        else { Console.WriteLine("Invalid GPA"); return 'I'; }
    }

    #endregion

    #region Ques 4
    public class MeditationCenter
    {
        public int MemberId { get; set; } 
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Goal { get; set; }
        public double BMI { get; }

        public MeditationCenter(int memberId, int age, double weight, double height, string goal, double bMI)
        {
            MemberId = memberId;
            Age = age;
            Weight = weight;
            Height = height;
            Goal = goal;
            BMI = bMI;
        }
    }

    public static ArrayList memberList = new ArrayList();

    //public void AddYogaMember(int Memberid, int age, double weight, )

    #endregion






}