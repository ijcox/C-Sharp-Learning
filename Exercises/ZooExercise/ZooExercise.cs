using System;
using System.Collections.Generic;

public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a sound.");
    }

}

public class Lion : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Roar!");
    }
}

public class Elephant : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Trumpet!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal a1 = new Lion();
        Animal a2 = new Elephant();
        Animal a3 = new Lion();

        List<Animal> animals = new List<Animal>();

        animals.Add(a1);
        animals.Add(a2);
        animals.Add(a3);

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }
}
