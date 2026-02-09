namespace XamXpert
{
    public interface IExam
    {
        public double calculateScore();
        public static string evaluateResult(double percentage)
        {
            if (percentage >= 85) { return "Merit"; }
            else if(percentage>= 60 && percentage < 85) { return "Pass"; }
            else { return "Fail"; }
        }
    }

    public class OnlineTest : IExam
    {
        public string studentName { get; set; }
        public int totalQuestions { get; set; }
        public int correctAnswers { get; set; }
        public int wrongAnswers { get; set; }
        public string questionType { get; set; }

        public OnlineTest()
        {

        }

        public double calculateScore()
        {
            if (questionType.ToLower().Trim() == "mcq")
            {
                int marksPerQuestion = 2;
                double totalScore = (correctAnswers * marksPerQuestion) - (wrongAnswers * marksPerQuestion * 0.10);
                return Math.Round(totalScore,0);
            }
            else
            {
                int marksPerQuestion = 5;
                double totalScore = (correctAnswers * marksPerQuestion) - (wrongAnswers * marksPerQuestion * 0.10);
                double percentage = (totalScore / (totalQuestions * marksPerQuestion)) * 100;
                return Math.Round(totalScore, 0);
            }
        }

        public double calculatePercentage()
        {
            if (questionType.ToLower().Trim() == "mcq")
            {
                int marksPerQuestion = 2;
                double percentage = (calculateScore() / (totalQuestions * marksPerQuestion)) * 100;
                return percentage;
            }
            else
            {
                int marksPerQuestion = 5;
                double percentage = (calculateScore() / (totalQuestions * marksPerQuestion)) * 100;
                return percentage;
            }
        }
    }

    public class UserInterface
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Exam Details :");
            Console.WriteLine("\nStudent Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Question Type (MCQ/Coding)");
            string type = Console.ReadLine();
            Console.WriteLine("Total Questions: ");
            int total = int.Parse(Console.ReadLine());
            Console.WriteLine("Correct Answers : ");
            int correct = int.Parse(Console.ReadLine());
            Console.WriteLine("Wrong Answers : ");
            int wrong = int.Parse(Console.ReadLine());
            Console.WriteLine();

            OnlineTest ot = new OnlineTest()
            {
                studentName = name,
                totalQuestions = total,
                correctAnswers = correct,
                wrongAnswers = wrong,
                questionType = type
            };

            Console.WriteLine("Exam Summary : ");
            Console.WriteLine();
            double percent = ot.calculatePercentage();
            Console.WriteLine($"{type} Test : {name}, Total Score: {ot.calculateScore()}, Result : {IExam.evaluateResult(percent)}");
        }
    }
}