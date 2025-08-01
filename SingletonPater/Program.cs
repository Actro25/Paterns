using System;
class Logger 
{
    private Logger() { }
    private static Logger _instance;
    private static readonly Object _lock = new Object();
    public static Logger Instance 
    {
        get 
        {
            lock (_lock) 
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
    }
    public void Log(string Message)
    {
        Console.WriteLine($"[LOG] -{DateTime.Now}- {Message}");
    }
}
class ActionCounter
{
    private static ActionCounter _instance;
    private static readonly Object _lock = new Object();
    private static int _count = 0;
    private static bool _maxCountReached = false;
    private static List<string> _actionDescription = new List<string>();
    private ActionCounter() { }
    public static ActionCounter Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ActionCounter();
                }
                return _instance;
            }
        }
    }
    public void Increment()
    {
        if (_maxCountReached) 
        {
            Logger.Instance.Log("Max Count Reached at 10 points");
            return;
        }

        _count++;
        Logger.Instance.Log($"Action count incremented to {_count}");

        if (_count == 10)
            _maxCountReached = true;
    }
    public int GetCount()
    {
        return _count;
    }
    public void Reset()
    {
        _count = 0;
        _maxCountReached = false;
    }
    public void AddAction(string actionDescription)
    {
        _actionDescription.Add(actionDescription);
    }
    public List<string> GetActions()
    {
        return _actionDescription;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Logger.Instance.Log("Application started");
        ActionCounter counter = ActionCounter.Instance;
        counter.Increment();
        counter.AddAction("First action performed");
        
        for (int i = 0; i < 10; i++)
        {
            counter.Increment();
            counter.AddAction($"Action {i + 1} performed");
        }
        Logger.Instance.Log($"Total actions performed: {counter.GetCount()}");
        
        if (counter.GetCount() >= 10)
        {
            Logger.Instance.Log("Max action count reached, resetting...");
            counter.Reset();
        }
        Logger.Instance.Log("Application ended");
    }

}