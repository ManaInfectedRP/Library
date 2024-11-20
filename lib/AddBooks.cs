namespace lib;

public class AddBooks
{
    public static void AddBook(Library library)
    {
        bool addingBooks = true;
        while (addingBooks)
        {
            Console.WriteLine("\nEnter book title (or type 'exit' to stop adding books):");
            string title = Console.ReadLine();
            if (title.ToLower() == "exit") break;
 
            Console.WriteLine("Enter author name:");
            string author = Console.ReadLine();
 
            Console.WriteLine("Enter publisher name:");
            string publisher = Console.ReadLine();
            
            Console.WriteLine("Select a department for the book:");
            for (int i = 0; i < library.Departments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {library.Departments[i]}");
            }
 
            int departmentIndex;
            while (true)
            {
                Console.Write("Enter the number corresponding to the department: ");
                if (int.TryParse(Console.ReadLine(), out departmentIndex) && departmentIndex > 0 && departmentIndex <= library.Departments.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please enter a valid number.");
                }
            }
 
            string department = library.Departments[departmentIndex - 1];
 
            library.AddBook(new Book(title, author, publisher, department));
            Console.WriteLine("Book added successfully!");
        }
    }
}