using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is Book other)
            {
                return Title == other.Title && Author == other.Author && Year == other.Year;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Year);
        }
    }
}
