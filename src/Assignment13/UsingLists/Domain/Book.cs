using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLists.Domain
{
    public class Book
    {
        public Book(string title)
        {
            this.Title = title;
        }

        public string Title { get; set; }
    }
}
