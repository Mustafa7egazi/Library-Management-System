namespace LibraryManagementSystem
{
    internal class Library
    {
        private static Book[] books = new Book[100];
        private static Book[] borrowedBooks = new Book[50];
        private int currentBookCount = 0;
        private int currentBorrowedBooksCount = 0;

        public void Display()
        {
            Console.WriteLine("========================= Available books =========================");
            if (currentBookCount!=0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                for (int i = 0; i < currentBookCount; i++)
                {
                    Console.WriteLine(books[i].Title);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                showFailMessage("No books right now!");
            }

        }

        public void Add(Book book)
        {
            if (currentBookCount < books.Length)
            {
                books[currentBookCount++] = book;
                showSuccessMessage("Book added successfully!");
            }
            else
            {
                showFailMessage("Library shelfs are full, can't add new item!");
            }
        }

        public void Remove(Book book)
        {
            int index = Array.IndexOf(books, book);
           
            if (index != -1)
            {
                books[index] = null;
                // Shift elements left
                for (int i = index; i < currentBookCount - 1; i++)
                {
                    books[i] = books[i + 1];                   
                }
                currentBookCount--;
                showSuccessMessage("Book removed successfully!");
            }
            else
            {
                showFailMessage("No such book!");
            }
        }

        public void LentBook(Book book) 
        {
            if (currentBorrowedBooksCount < borrowedBooks.Length)
            {
                int index = Array.IndexOf(books, book);
                if (index != -1)
                {
                    books[currentBorrowedBooksCount++] = book;
                    showSuccessMessage("Book Borrowed successfully!");
                }
                else
                {
                    showFailMessage("No such book!");
                }
               
            }
            else
            {
                showFailMessage("Sorry can't lent you right now, max amount reached!");
            }
        }

        private void showSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void showFailMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
