public class Vehicle
{
    private string _make, _model;
    private int _year;

    public Vehicle(string make, string model, int year)
    {
        _make = make;
        _model = model;
        _year = year;

    }
    public string Make { get { return _make; } set { _make = value; } }
    public string Model { get { return _model; } set { _model = value; } }
    public int Year { get { return _year; } set { _year = value; } }

    public virtual void Describe()
    {
        Console.WriteLine($"{Year} {Make} {Model}");
    }

}

public class Car : Vehicle
{
    private int _doors;

    public Car(string make, string model, int year, int doors)
        : base(make, model, year)
    {
            _doors = doors;
    }

    public int Doors { get { return _doors; } set { _doors = value; } }

    public override void Describe()
    {
        Console.WriteLine($"{Year} {Make} {Model} with {Doors} doors");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car myCar = new Car("Toyota", "Camry", 2021, 4);
        myCar.Describe();
    }
}
