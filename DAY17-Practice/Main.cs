namespace MainClass;

using Questions;
using QuestionsCopy;


public class MainClass
{
    public static void Main(string[] args)
    {
        #region Ques1
        Program p = new Program();

        Console.WriteLine("\n===============Ques 1 Outputs===============");

        p.AddItems("Books", 10000);
        p.AddItems("Magazines", 5000);
        p.AddItems("Pen", 20000);

        Console.WriteLine("Found Item: ");
        foreach (var i in p.FindItemDetails(20000)) { Console.WriteLine(i); }
        Console.WriteLine("\nMin and Max Sold Items: ");
        foreach (var i in p.FindMinAndMaxSoldItems()) { Console.Write(i+ " "); }
        Console.WriteLine();
        Console.WriteLine("\nSorted Dictionary : ");
        foreach (var i in p.SortByCount()) { Console.WriteLine(i); }
        #endregion

        #region Ques2
        Console.WriteLine("\n===============Ques 2 Outputs===============");
        p.AddMovie("Interstellar,Christopher Nolan,Science,10");
        p.AddMovie("Thor: Ragnarok, Kevin Feige,Drama Fantasy,8");
        p.AddMovie("Inception,Christopher Nolan,Sci-Fi,9");
        p.AddMovie("Chernobyl,Unknown,Documentary,10");
        Console.WriteLine("\nAdded Movie Successfully.");

        Console.WriteLine("\nMovies by Genre: ");
        foreach (var m in p.ViewMoviesByGenre("Sci-Fi")) 
        {
            Console.WriteLine($"Title: {m.Title}"); 
        }

        Console.WriteLine("\nMovies By Increasing Ratings: ");
        foreach (var m in p.ViewMoviesByRating()) 
        { 
            Console.WriteLine($"Title : {m.Title}, Artist : {m.Artist}, Genre: {m.Genre}, Rating: {m.Ratings}"); 
        }

        #endregion

        #region Ques3

        Console.WriteLine("\n===============Ques 3 Outputs===============");
        p.AddNumbers(2); 
        p.AddNumbers(9);
        p.AddNumbers(4);
        p.AddNumbers(8);
        Console.WriteLine("\nNumbers Added Successfully.");

        Console.WriteLine("\nGPA: ");
        double res = p.GetGPAScored();
        Console.WriteLine(res);

        Console.WriteLine("\nGrade: ");
        Console.WriteLine(p.GetGradeScored(res));
        #endregion

        #region QuestionsCopy
        Console.WriteLine("\n============Questions Copy Ques 1===================");
        ProgramCopy pr = new ProgramCopy();
        ProgramCopy.itemDetails.Add("Chains", 1000);
        ProgramCopy.itemDetails.Add("Key", 5000);
        ProgramCopy.itemDetails.Add("Locks", 2000);

        Console.WriteLine("\nFinding Item Details: ");
        foreach (var i in pr.FindItemDetails(5000)) { Console.WriteLine(i); }

        Console.WriteLine("\nMin and Max: ");
        foreach (var i in pr.FindMinAndMaxSoldItems()) { Console.WriteLine(i); }

        Console.WriteLine("\nSorted by Count: ");
        foreach (var i in pr.sortByCount()) { Console.WriteLine(i); }


        Console.WriteLine("\n============Questions Copy Ques 2===================");
        string movie1 = "Interstellar, Brad Pitt, Science, 9.1";
        string movie2 = "Oppenhiemer, Cillian Murphy, Biography, 8.2";
        string movie3 = "Chernobyl, Unknown, Documentary, 9.5";
        pr.AddMovie(movie1); pr.AddMovie(movie2); pr.AddMovie(movie3);

        string Genre = "Documentary";
        Console.WriteLine("\nMovie By Genre: ");
        foreach (var i in pr.ViewMoviesByGenre(Genre)) { Console.WriteLine(i.Title); }

        Console.WriteLine("\nMovies By Ratings Ordered: ");
        foreach (var i in pr.ViewMoviesByRatings()) { Console.WriteLine(i.Title+" "+i.Rating); }

        Console.WriteLine("\n============Questions Copy Ques 3===================");
        int num1 = 5; int num2 = 8; int num3 = 9;
        pr.AddNumber(num1);
        pr.AddNumber(num2);
        pr.AddNumber(num3);

        double gpa = pr.GetGPAScored();
        Console.WriteLine($"\nGPA: {gpa}");
        Console.WriteLine($"\nGrade: {pr.GetGradeScored(gpa)}");


        #endregion


    }
}