using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    class Book : Literature
    {
        [Required]
        public Genre genre { get; }
        public Book(string title, string author_name, Genre genre, int year, int pages, int count) : base(title, author_name, year, pages, count)
            {
            this.genre = genre;
            }

    }
}
