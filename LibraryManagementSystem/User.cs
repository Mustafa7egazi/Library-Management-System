using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    abstract class User
    {
        public string Name { get; set; }

        public void DisplayBooks(Library lib)
        {
            lib.Display();
        }
    }
}
