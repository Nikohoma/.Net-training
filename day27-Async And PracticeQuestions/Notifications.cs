//Notifications - Interface + Multiple Implementations
//A system can send the same alert through multiple channels.
//Requirements:
//•	Create interface INotifier with method Send(string message).
//•	Implement EmailNotifier, SmsNotifier, WhatsAppNotifier.
//Task: Store notifiers in an array/list and send a single message to all.


namespace Notifications
{
    public interface INotifier
    {
        void Send(string message);
    }

    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email : {message}");
        }
    }
    public class SMSNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS : {message}");
        }
    }
    public class WhatsAppNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"WhatsApp : {message}"); ;
        }
    }

    public class User
    {
        static List<string> notifications = new List<string>();

        public static void Main(string[] args)
        {
            INotifier notifier;

            notifier = new EmailNotifier();
            notifier.Send("Message Sent");
            notifications.Add("Email : Message Sent.");
            notifier = new SMSNotifier();
            notifier.Send("Message Sent");
            notifications.Add("SMS : Message Sent.");
            notifier = new WhatsAppNotifier();
            notifier.Send("Message Sent");
            notifications.Add("WhatsApp : Message Sent.");

            Console.WriteLine("Notification Log : ");
            foreach (var s in notifications)
            {
                Console.WriteLine(s);
            }
        }

    }
}