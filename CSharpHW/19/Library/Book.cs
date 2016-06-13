using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        public string title { get; }
        public string author_name { get; }
        public int year { get; }
        public int pages { get; }
        public int pop_index { get; set; }
        public Genre genre { get; }
        public int max_count { get; }
        public int count { get; set; }
        public string last_taken_by { get; set; }

        public Book(string title, string author_name, Genre genre, int year, int pages, int count)
        {
            this.title = title;
            this.author_name = author_name;
            this.genre = genre;
            this.year = year;
            this.pages = pages;
            this.pop_index = 0;
            this.count = this.max_count = count;
            this.last_taken_by = "no one";
        }

        public void Change_last_user(User user)
        {
            last_taken_by = user.login;
        }
    }
}
