namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

        resign:
            Console.Write("Welcome to the library!" +
                "\nSign in as Regular User (R) or Librarian (L): ");

        rechoice:
            var userType = Console.ReadLine().ToUpper()[0];
            if (userType == 'L')
            {
                Console.Write("Enter your name please: ");
                var theGuyName = Console.ReadLine();
                Librarian l1 = new Librarian(theGuyName);
                Console.WriteLine($"Hi there,{theGuyName}. How is it going?");
                while (true)
                {
                    afterCatchingFormatError:
                    Console.WriteLine("===================================================================");
                    Console.Write("Tell us what do you want  'NOTE: only the first character is considered'" +
                        "\n(1) Add new book to the collection" +
                        "\n(2) Remove a book from the collection" +
                        "\n(3) Display all books in the collection" +
                        "\n(4) Re-sign with diffrent credentials" +
                        "\nelse [EXIT]" +
                        "\n===================================================================" +
                        "\nchoice: ");

                    var theGuyChoice = Console.ReadLine().ToUpper()[0];
                    try
                    {
                        switch (theGuyChoice)
                        {
                            case '1':
                                Console.WriteLine("Enter book details");
                                Console.Write("Book Name: ");
                                string bookName = Console.ReadLine().Trim();
                                Console.Write("Book Author: ");
                                string bookAuthor = Console.ReadLine().Trim();
                                Console.Write("Year of publish: ");
                                int yearOfPublish = Convert.ToInt32(Console.ReadLine());

                                Book book = new Book()
                                {
                                    Title = bookName,
                                    Author = bookAuthor,
                                    Year = yearOfPublish
                                };

                                l1.AddBook(book, library);
                                break;
                            case '2':
                                Console.WriteLine("Enter book details to remove");
                                Console.Write("Book Name: ");
                                bookName = Console.ReadLine().Trim();
                                Console.Write("Book Author: ");
                                bookAuthor = Console.ReadLine().Trim();
                                Console.Write("Year of publish: ");
                                yearOfPublish = Convert.ToInt32(Console.ReadLine());

                                book = new Book()
                                {
                                    Title = bookName,
                                    Author = bookAuthor,
                                    Year = yearOfPublish
                                };

                                l1.RemoveBook(book, library);
                                break;
                            case '3':
                                l1.DisplayBooks(library);
                                break;
                            case '4':
                                goto resign;
                            default:
                                Environment.Exit(0);
                                break;
                        }
                    }catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto afterCatchingFormatError;
                    }
                }

            }
            else if (userType == 'R')
            {
                Console.Write("Enter your name please: ");
                var theGuyName = Console.ReadLine();
                LibraryUser libraryUser = new LibraryUser(theGuyName);
                Console.WriteLine($"Hi there,{theGuyName}. How is it going?");

                while (true)
                {
                    afterCatchingFormatError:
                    Console.WriteLine("===================================================================");
                    Console.Write("Tell us what do you want  'NOTE: only the first character is considered'" +
                        "\n(1) Display all books in the collection" +
                        "\n(2) Borrow a book from the collection" +
                        "\nelse [EXIT]" +
                        "\n===================================================================" +
                        "\nchoice: ");

                    var theGuyChoice = Console.ReadLine().ToUpper()[0];
                    switch (theGuyChoice)
                    {
                        case '1':
                            libraryUser.DisplayBooks(library);
                            break;
                        case '2':
                            try
                            {
                                Console.WriteLine("Enter book details you want to borrow");
                                Console.Write("Book Name: ");
                                string bookName = Console.ReadLine().Trim();
                                Console.Write("Book Author: ");
                                string bookAuthor = Console.ReadLine().Trim();
                                Console.Write("Year of publish: ");
                                int yearOfPublish = Convert.ToInt32(Console.ReadLine());

                                Book book = new Book()
                                {
                                    Title = bookName,
                                    Author = bookAuthor,
                                    Year = yearOfPublish
                                };

                                libraryUser.BorrowBook(book, library);
                            }catch(FormatException e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(e.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                goto afterCatchingFormatError;
                            }
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
                goto rechoice;
            }
        }
    }
}
