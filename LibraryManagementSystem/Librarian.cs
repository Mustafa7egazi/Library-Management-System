using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Librarian : User
    {
        public int EmployeeNumber { get; set; }

        public Librarian(string name)
        {
            Name = name;
        }

        public void AddBook(Book newBook,Library lib)
        {
            lib.Add(newBook);
        }

        public void RemoveBook(Book theBook,Library lib)
        {
            lib.Remove(theBook);
        }
    }
}
