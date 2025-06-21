using System;

public class Book
{
    private string _title, _author;
    private int _pages;

    public Book(string title, string author, int pages)
    {
        _title = title;
        _author = author;
        _pages = pages;
    }

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }

    public int Pages
    {
        get { return _pages; }
        set { _pages = value; }
    }

    public void Describe()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Pages: {Pages}");
    }

    static void Main(string[] args)
    {
        Book myBook = new Book("1984", "George Orwell", 328);
        myBook.Describe();
    }

}