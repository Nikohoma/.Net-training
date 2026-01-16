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

    /// <summary>
    /// MeditationCenter Data Type Definition
    /// </summary>
    public class MeditationCenter
    {
        public int MemberId { get; set; } 
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Goal { get; set; }
        public double BMI { get; set; }

        /// <summary>
        /// Meditation Center Constructor
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="age"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="goal"></param>
        public MeditationCenter(int memberId, int age, double weight, double height, string goal)
        {
            MemberId = memberId;
            Age = age;
            Weight = weight;
            Height = height;
            Goal = goal;
            BMI = 0;
        }
    }

    /// <summary>
    /// memberList ArrayList to store the details of all the Members.
    /// </summary>
    public static ArrayList memberList = new ArrayList();


    /// <summary>
    /// Method to new members to the memberList
    /// </summary>
    /// <param name="Memberid"></param>
    /// <param name="age"></param>
    /// <param name="weight"></param>
    /// <param name="height"></param>
    /// <param name="goal"></param>
    public void AddYogaMember(int Memberid, int age, double weight, double height, string goal)
    {
        MeditationCenter mc = new MeditationCenter(Memberid, age, weight, height, goal);
        memberList.Add(mc);
    }

    /// <summary>
    /// Method to calculate BMI and adding it to the memberList
    /// </summary>
    /// <param name="memberId"></param>
    /// <returns></returns>
    public double CalculateBMI(int memberId)
    {
        bool found = false;
        double CalculatedBMI = 0;
        foreach(MeditationCenter m in memberList)
        {
            if (m.MemberId == memberId)
            {
                CalculatedBMI = (m.Weight) / (m.Height * m.Height);
                m.BMI = CalculatedBMI;
                found = true;
            }
        }

        if (!found) { Console.WriteLine($"Member ID : {memberId} is not Present. "); }        
        return Math.Floor(CalculatedBMI);
    }

    /// <summary>
    /// Method to calculate Yoga Fee based on goals.
    /// </summary>
    /// <param name="memberId"></param>
    /// <returns></returns>
    public int CalculateYogaFee(int memberId)
    {
        int CalculatedYogaFee = 0; int WeightGain = 2500;
        foreach (MeditationCenter m in memberList)
        {
            if (m.MemberId == memberId)
            {
                CalculateBMI(memberId);
                if (m.Goal == "Weight Loss")
                {
                    if (m.BMI >= 25 && m.BMI < 30) { CalculatedYogaFee = 2000; return CalculatedYogaFee; }
                    if (m.BMI >= 30 && m.BMI < 35) { CalculatedYogaFee = 2000; return CalculatedYogaFee; }
                    else { CalculatedYogaFee = 2000; return CalculatedYogaFee; }


                }
                else { return WeightGain; }
            }
            
        }
        Console.WriteLine($"Member ID {memberId} not found. ");
        return -1;
    }

    #endregion

    #region Ques5

    /// <summary>
    /// Ecommerce Data Type 
    /// </summary>
    public class EcommerceShop
    {
        // Properties 
        public string UserName { get; set; }
        public double WalletBalance { get; set; }
        public double TotalPurchaseAmount { get; set; }

        // Constructor
        public EcommerceShop(string UserName,double WalletBalance, double TotalPurchaseAmount)
        {
            this.UserName = UserName; this.WalletBalance = WalletBalance; this.TotalPurchaseAmount = TotalPurchaseAmount;
        }
    }

    /// <summary>
    /// Custom Exception 
    /// </summary>
    public class InsufficientWalletBalance : Exception
    {
        public InsufficientWalletBalance(string message) : base(message) { } 
    }

    /// <summary>
    /// Method to Calculate Payment to make. Throws error if not sufficient balance.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="balance"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="InsufficientWalletBalance"></exception>
    public EcommerceShop MakePayment(string name, double balance,double amount)
    {
        EcommerceShop e1 = new EcommerceShop(name,balance,amount);
        if (balance < amount) { throw new InsufficientWalletBalance("Insufficient Balance in your digital wallet"); }
        else { e1.WalletBalance -= amount; }
        Console.WriteLine($"UserName : {e1.UserName}, Balance: {e1.WalletBalance}");
        return e1;
    }



    #endregion

    #region Ques6
    public class User
    {
        // Properties
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }

        // Constructor 
        public User(string Name, string Password, string ConfirmationPassword)
        {
            this.Name = Name; this.Password = Password; this.ConfirmationPassword = ConfirmationPassword;
        }
    }


    /// <summary>
    /// Custom Exception
    /// </summary>
    public class PasswordMismatchException : Exception
    {
        public PasswordMismatchException(string msg) : base(msg)
        {
            
        }
    }

    public User ValidatePassword(string name, string password, string confirmationPassword)
    {
        if (password == confirmationPassword)
        {
            User u = new User(name, password, confirmationPassword);
            return u;
        }
        else { throw new PasswordMismatchException("Password entered does not match."); }
    }



    #endregion

    #region Ques7 

    /// <summary>
    /// EstimateDetails data type
    /// </summary>
    public class EstimateDetails
    {
        // Properties
        public float ConstructionArea { get; set; }
        public float SiteArea { get; set; }

        //Constructor
        public EstimateDetails(float ConstructionArea, float SiteArea)
        {
            this.ConstructionArea = ConstructionArea; this.SiteArea = SiteArea;
        }

    }

    /// <summary>
    /// Custom Exception if ConstructionArea > SiteArea
    /// </summary>
    public class ConstructionEstimateException : Exception
    {
        public ConstructionEstimateException(string msg) : base(msg)
        {

        }
    }


    /// <summary>
    /// Method to Validate Construction.
    /// </summary>
    /// <param name="constructionArea"></param>
    /// <param name="siteArea"></param>
    /// <returns></returns>
    /// <exception cref="ConstructionEstimateException"></exception>
    public EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea)
    {
        if (constructionArea < siteArea)
        {
            EstimateDetails e = new EstimateDetails(constructionArea, siteArea);
            return e;
        }
        else
        {
            throw new ConstructionEstimateException("Soryy your construction estimate is not approved.");
        }
    }



    #endregion

    #region Ques 8 

    /// <summary>
    /// Verified USer Data Type
    /// </summary>
    public class VerifiedUser
    {
        // Properties
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor 
        public VerifiedUser(string Name ,string PhoneNumber)
        {
            this.Name = Name; this.PhoneNumber = PhoneNumber;
        }
    }


    /// <summary>
    /// Custom Exception if Invalid Phone Number
    /// </summary>
    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string msg) : base(msg)
        {

        }
    }


    /// <summary>
    /// Method to verify User Phone Number
    /// </summary>
    /// <param name="name"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    /// <exception cref="InvalidPhoneNumberException"></exception>
    public VerifiedUser ValidatePhoneNumber(string name, string phoneNumber)
    {
        if (phoneNumber.Length == 10)
        {
            VerifiedUser vu = new VerifiedUser(name, phoneNumber);
            return vu;
        }
        else { throw new InvalidPhoneNumberException("Invalid Phone Number"); }
    }


    #endregion


}