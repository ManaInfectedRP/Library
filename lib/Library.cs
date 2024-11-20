namespace lib;

public class Library
{
    private List<Book> books;
    private const string FilePath = "./data.csv";
    public List<string> Departments;    

    public Library()
    {
        books = new List<Book>();
        LoadBooks();
        
        Departments = new List<string> { "Nonfiction", "Fiction", "Science", "History", "Biography" };
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        SaveBook(book);
    }

    public List<Book> SearchByAuthor(string author)
    {
        return books.Where(b => b.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    public List<Book> GetBooksByPublisher(string publisher)
    {
        return books.Where(b => b.Publisher.IndexOf(publisher, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    public List<Book> GetBooksByDepartment(string department)
    {
        return books.Where(b => b.Department.Equals(department, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> GetAllBooks()
    {
        return books.ToList();
    }

    private void LoadBooks()
    {
        if (!File.Exists(FilePath))
        {
            return;
        }
        
        foreach (var line in File.ReadAllLines(FilePath))
        {
            var data = line.Split(',');
            if (data.Length == 4)
            {
                var book = new Book(data[0], data[1], data[2], data[3]);
                books.Add(book);
            }
        }
    }
    private void SaveBook(Book book)
    {
        using (var writer = new StreamWriter(FilePath, true))
        {
            writer.WriteLine($"{book.Title},{book.Author},{book.Publisher},{book.Department}");
        }
    }
    
    public bool RemoveBook(string title)
    {
        Book bookToRemove = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            SaveBooksToFile();
            return true;
        }
        return false;
    }
     
    private void SaveBooksToFile()
    {   
        using (StreamWriter writer = new StreamWriter(FilePath, false))
        {
            foreach (var book in books)
            {
                writer.WriteLine($"{book.Title},{book.Author},{book.Publisher},{book.Department}");
            }
        }
    }
}
