namespace lib;
using System;

public class SearchBooks
{
    public static void SearchBook(Library library)
    {
        bool searching = true;
        while (searching)
        {
            Console.WriteLine("\nChoose an option to search:");
            Console.WriteLine("1. Search by Author");
            Console.WriteLine("2. Search by Publisher");
            Console.WriteLine("3. Search by Department");
            Console.WriteLine("4. Find All Books");
            Console.WriteLine("5. Exit Search");
     
            string option = Console.ReadLine();
     
            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter part or full author name to search for:");
                    string authorName = Console.ReadLine();
                    var authorBooks = library.SearchByAuthor(authorName);
     
                    Console.WriteLine($"\nBooks by authors containing '{authorName}':");
                    if (authorBooks.Count > 0)
                    {
                        foreach (var book in authorBooks)
                            Console.WriteLine(book.Title + ": " + book.Author);
                    }
                    else
                    {
                        Console.WriteLine("No books found for this author.");
                    }
                    break;
     
                case "2":
                    Console.WriteLine("Enter a publisher name to search for:");
                    string publisherName = Console.ReadLine();
                    var publisherBooks = library.GetBooksByPublisher(publisherName);
     
                    Console.WriteLine($"\nBooks by '{publisherName}':");
                    if (publisherBooks.Count > 0)
                    {
                        foreach (var book in publisherBooks)
                            Console.WriteLine(book.Title + ": " + book.Author);
                    }
                    else
                    {
                        Console.WriteLine("No books found for this publisher.");
                    }
                    break;
     
                case "3":
                    Console.WriteLine("Select a department: ");
                    for (int i = 0; i < library.Departments.Count; i++)
                    {
                        Console.WriteLine($"{i +1}, {library.Departments[i]}");
                    }

                    int departmentIndex;
                    while (true)
                    {
                        Console.WriteLine("Enter the number corresponding to the departmentIndex: ");
                        if (int.TryParse(Console.ReadLine(), out departmentIndex)
                            && departmentIndex > 0
                            && departmentIndex <= library.Departments.Count)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Section. Please enter a valid Number.");
                        }
                    }

                    string department = library.Departments[departmentIndex - 1];
                    var booksByDepartment = library.GetBooksByDepartment(department);
                    Console.WriteLine($"Books in the '{department}' department: ");
                    foreach (var book in booksByDepartment)
                    {
                        Console.WriteLine(book.Title  + ": " + book.Author);
                    }
                    break;
     
                case "4":
                    var allBooks = library.GetAllBooks();
                    Console.WriteLine("All Books in the library: ");
                    foreach (var book in allBooks)
                    {
                        Console.WriteLine(book.Title
                                          + ", Author: " + book.Author
                                          + ", Publisher:"+book.Publisher
                                          + ", Department: " + book.Department
                                          );
                    }
                    break;
                
                case "5":
                    searching = false;
                    break;
     
                default:
                    Console.WriteLine("Invalid option. Please select a valid number (1-4).");
                    break;
            }
        }
    }
}