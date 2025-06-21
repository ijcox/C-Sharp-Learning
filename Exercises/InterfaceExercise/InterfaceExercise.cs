using System;

public interface IRunnable
{
    void Run();
}

public abstract class Machine
{
    public string Name { get; }

    public Machine(string name)
    {
        Name = name;
    }

    public abstract void Start();
}

public class Robot : Machine, IRunnable
{
    public Robot(string name) : base(name) { }

    public override void Start()
    {
        Console.WriteLine($"{Name} is starting...");
    }

    public void Run()
    {
        Console.WriteLine($"{Name} is running...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Robot robo = new Robot("Robo 1");
        robo.Start();
        robo.Run();

    }
}
