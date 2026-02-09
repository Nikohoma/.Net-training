//Email Cleaner - Trim + Lower + Replace
//Customer emails arrive with extra spaces and mixed casing.
//Requirements:
//•	Trim spaces
//•	Convert to lowercase
//•	If domain is gmail.com, replace it with company.com
//Task: Input raw email and print cleaned email. Example: '  GOpi.Suresh@GMAIL.com  '-> 'gopi.suresh@company.com'.


namespace EmailCleaner
{
    public class User
    {
        public void CleanEmail(string email)
        {
            email = email.ToLower().Trim();
            email = email.Replace(" ","");
            email = email.Replace("gmail", "company");
            Console.WriteLine($"Cleaned Email : {email}");

        }
        public static void Main()
        {
            User u = new User();
            u.CleanEmail("GOpi.   Suresh@GMAIL.com    ");
        }
    }

    
}