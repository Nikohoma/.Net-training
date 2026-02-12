namespace day29
{
    public class EmailValidity
    {
        public bool CheckMail(string email)
        {
            if (string.IsNullOrEmpty(email)) { return false; }

            string[] parts = email.Split("@");
            if (parts.Length <2 || parts.Length >2) { return false; }
            if (parts[1].ToLower().Contains("gmail.com") && parts[1].Trim().Length == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            EmailValidity ev = new EmailValidity();
            var output = ev.CheckMail("asdh@gmail.com@gmail.com");
            Console.WriteLine(output);
        }
    }
}