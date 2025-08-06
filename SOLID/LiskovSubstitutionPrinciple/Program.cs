using System;
interface IVehicle 
{
    void Drive();
}
interface IBoat
{
    void Sail();
}
class Car : IVehicle
{
    public void Drive() {     
        Console.WriteLine("Driving a car.");
    }
}
class Bicycle : IVehicle
{
    public void Drive() {     
        Console.WriteLine("Riding a bicycle.");
    }
}
class Boat : IBoat
{
    public void Sail() {     
        Console.WriteLine("Sailing a boat.");
    }
}
class ShowFunctionality
{
    static public void Show(IVehicle vehicle)
    {
        vehicle.Drive();
    }
    static public void Show(IBoat boat)
    {
        boat.Sail();
    }
}
class Program
{
    static void Main(string[] args)
    {
        IBoat myBoat = new Boat();
        IVehicle myCar = new Car();
        IVehicle myBicycle = new Bicycle();
        ShowFunctionality.Show(myBoat);
        ShowFunctionality.Show(myCar);
        ShowFunctionality.Show(myBicycle);
    }
}