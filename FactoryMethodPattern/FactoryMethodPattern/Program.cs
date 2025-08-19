abstract class NotificationBase { abstract public void Send(string message); }
class EmailNotification : NotificationBase { public override void Send(string message) => Console.WriteLine($"Email sent: {message}"); }
class SMSNotification : NotificationBase { public override void Send(string message) => Console.WriteLine($"SMS sent: {message}"); }
class PushNotification : NotificationBase { public override void Send(string message) => Console.WriteLine($"Push sent: {message}"); }
class NotificationFactory {
    private static NotificationFactory _instance;
    private static Object _lock = new Object();
    private NotificationFactory() { }
    public static NotificationFactory Instance 
    { 
        get
        {
            lock (_lock) {                 
                if (_instance == null) 
                {
                    _instance = new NotificationFactory();
                }
                return _instance;
            }
        } 
    }
    public NotificationBase CreateNotification(string type) {
        return type switch {
            "email" => new EmailNotification(),
            "sms" => new SMSNotification(),
            "push" => new PushNotification(),
            _ => throw new ArgumentException("Invalid notification type")
        };
    }
}
class Program
{
    public static void Main(string[] args)
    {
        var type = Console.ReadLine();
        NotificationFactory.Instance.CreateNotification(type).Send(Console.ReadLine());
    }
}