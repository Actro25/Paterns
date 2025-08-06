using System;
interface IWages {
    double GetSalary();
}
class FullTimeEmployee : IWages
{
    private double _salary;
    public FullTimeEmployee(double salary)
    {
        _salary = salary;
    }
    public double GetSalary() => _salary;
}
class HourlyEmployee : IWages {
    private double _hours;
    private double _hoursMoney;
    public HourlyEmployee(double hours, double hoursMoney)
    {
        _hours = hours;
        _hoursMoney = hoursMoney;
    }
    public double GetSalary() => _hours * _hoursMoney;
}
class CommissionEmployee : IWages {
    private double _commission;
    private double _sales;
    public CommissionEmployee(double commission, double sales)
    {
        _commission = commission;
        _sales = sales;
    }
    public double GetSalary() => _commission * _sales;
}
class CalculateSalary {
    public static double Calculate(IWages wages)
    {
        return wages.GetSalary();
    }
}
class Program
{
    static void Main(string[] args)
    {
        IWages fullTime = new FullTimeEmployee(5000);
        IWages hourly = new HourlyEmployee(160, 20);
        IWages commission = new CommissionEmployee(0.1, 10000);
        Console.WriteLine($"Full Time Employee Salary: {CalculateSalary.Calculate(fullTime)}");
        Console.WriteLine($"Hourly Employee Salary: {CalculateSalary.Calculate(hourly)}");
        Console.WriteLine($"Commission Employee Salary: {CalculateSalary.Calculate(commission)}");
    }
}