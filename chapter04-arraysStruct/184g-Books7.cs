// Version history
// 0.07 - Delete
// 0.06 - Edit
// 0.05 - Search
// 0.04 - Display all; bugfix: count when adding
// 0.03 - Sort by title
// 0.02 - Add; sort by year
// 0.01 - Empty skeleton

using System;

class Books
{
    struct book
    {
        public string author;
        public string title;
        public int year;
    }
    static void Main()
    {
        const int CAPACITY = 25000;
        int amount = 0;
        book[] books = new book[CAPACITY];
        string option;

        do
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1- Add a new book");
            Console.WriteLine("2- Display all");
            Console.WriteLine("3- Search");
            Console.WriteLine("5- Edit");
            Console.WriteLine("6- Delete");
            Console.WriteLine("...");
            Console.WriteLine("X- Exit");
            option = Console.ReadLine().ToUpper();

            switch (option)
            {
                case "1": // Add
                    if (amount >= CAPACITY)
                    {
                        Console.WriteLine("Database full");
                    }
                    else
                    {
                        Console.Write("Enter author: ");
                        books[amount].author = Console.ReadLine();
                        Console.Write("Enter title: ");
                        books[amount].title = Console.ReadLine();
                        Console.Write("Enter year: ");
                        books[amount].year =
                            Convert.ToInt32(Console.ReadLine());
                        amount++;
                    }

                    for (int i = 0; i < amount - 1; i++)
                    {
                        for (int j = i + 1; j < amount; j++)
                        {
                            if (books[i].title.ToUpper().
                                CompareTo(books[j].title.ToUpper()) > 0)
                            {
                                book aux = books[i];
                                books[i] = books[j];
                                books[j] = aux;
                            }
                        }
                    }
                    break;

                case "2": // Show all
                    if (amount == 0)
                        Console.WriteLine("No data to display");
                    else
                    {
                        for (int i = 0; i < amount; i++)
                        {
                            Console.WriteLine((i+1) + ": " 
                                + books[i].author + " - "
                                + books[i].title + " - " 
                                + books[i].year);
                            if (i % 21 == 20)
                                Console.ReadLine(); // Pause after 21 rows
                        }
                    }
                    break;

                case "3": // Search
                    if (amount == 0)
                        Console.WriteLine("No data to search in");
                    else
                    {
                        string search = Console.ReadLine();
                        bool found = false;
                        for (int i = 0; i < amount; i++)
                        {
                            if (books[i].author.ToLower().Contains(
                                search.ToLower()))
                            {
                                Console.WriteLine((i + 1) + ": "
                                    + books[i].author + " - "
                                    + books[i].title + " - "
                                    + books[i].year);
                                found = true;
                            }
                        }
                        if (!found)
                            Console.WriteLine("Not found");
                    }
                    break;

                case "4": // Search 2
                    Console.WriteLine("Soon...");
                    break;

                case "5": // Edit
                    Console.Write("Enter book number to edit: ");
                    int editPosition = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (editPosition >= amount)
                    {
                        Console.WriteLine("There are not so many books");
                    }
                    else
                    {
                        Console.Write("Enter author (it was {0}): ",
                            books[editPosition].author);
                        string newText = Console.ReadLine();
                        if (newText != "")
                        {
                            books[editPosition].author = newText;
                            if (newText == newText.ToUpper())
                                Console.WriteLine("Beware: all uppercase");
                        }

                        Console.Write("Enter title (it was {0}): ",
                            books[editPosition].title);
                        newText = Console.ReadLine();
                        if (newText != "")
                            books[editPosition].title = newText;

                        Console.Write("Enter year (it was {0}): ",
                            books[editPosition].year);
                        newText = Console.ReadLine();
                        if (newText != "")
                            books[editPosition].year = 
                                Convert.ToInt32(newText);
                    }
                    break;

                case "6": // Delete
                    int deletePosition;

                    Console.Write("Enter book number to delete: ");
                    deletePosition = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (deletePosition >= amount)
                    {
                        Console.WriteLine("There are not so many books");
                    }
                    else
                    {
                        Console.WriteLine("This is the book you are deleting:");
                        Console.WriteLine(books[deletePosition].author);
                        Console.WriteLine(books[deletePosition].title);
                        Console.Write("Type Y to confirm deletion... ");

                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            for (int i = deletePosition; i < amount; i++)
                            {
                                books[i] = books[i + 1];
                            }
                            amount--;
                            Console.WriteLine("Deleted");
                        }
                        else
                            Console.WriteLine("Not deleted");
                    }
                    break;

                // TO DO ...

                case "X":
                    Console.WriteLine("Bye!!");
                    break;

                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
        }
        while (option != "X");
    }
}
