namespace lib;
class Program
{
    public static void Main()
    {
        Library library = new Library();
     
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add books");
            Console.WriteLine("2. Search for books");
            Console.WriteLine("3. Remove a books");
            Console.WriteLine("4. Exit");
     
            string mainOption = Console.ReadLine();
     
            switch (mainOption)
            {
                case "1":
                    AddBooks.AddBook(library);
                    break;
     
                case "2":
                    SearchBooks.SearchBook(library);
                    break;
                
                case "3":
                    Console.WriteLine("Enter the title of the book to remove: ");
                    string titleToRemove = Console.ReadLine();
                    bool removed = library.RemoveBook(titleToRemove);

                    if (removed)
                    {
                        Console.WriteLine("Book was removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;
     
                case "4":
                    Console.WriteLine("Exiting program.");
                    running = false;
                    break;
     
                default:
                    Console.WriteLine("Invalid option. Please select a valid number (1-3).");
                    break;
            }
        }
    }
}