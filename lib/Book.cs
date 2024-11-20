namespace lib;

public class Book
{
    public readonly string Title;
    public readonly string Author;
    public readonly string Publisher;
    public readonly string Department;
 
    public Book(string title, string author, string publisher, string department)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
        Department = department;
    }
}
