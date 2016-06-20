using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    [Serializable]
    public class Book : Literature
    {
        [Required]
        public Genre genre { get; set; }
        public Book(string title, string author_name, Genre genre, int year, int pages, int count) : base(title, author_name, year, pages, count)
        {
            this.genre = genre;
        }

        public Book()
        {
            this.genre = Genre.drama;
        }

    }
}
