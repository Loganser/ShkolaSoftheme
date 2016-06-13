using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    class User : IValidatableObject
    {
        public bool autorized { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 2)]
        public string login { get; set; }
        public List<Book> books_taken = new List<Book>();


        public User(string login)
        {
            this.login = login;
            this.autorized = false;
        }

        public void Set_privileges()
        {
            this.autorized = true;
        }
        public Book Take_book(string title, string author)
        {
            foreach (Book book in Library.books)
            {
                if (book.author_name.Equals(author) && book.title.Equals(title) && book.count > 0)
                {
                    book.count--;
                    book.pop_index++;
                    book.Change_last_user(this);
                    books_taken.Add(book);
                    Library.Update_journal(book);
                    return book;
                }
            }
            return null;
        }

        public bool Return_book(string title, string author)
        {
            foreach (Book book in Library.books)
            {
                bool found = false;
                foreach (Book book1 in books_taken)
                {
                    if (book.title.Equals(title) && book.author_name.Equals(author)) found = true;
                }

                if (book.title.Equals(title) && book.count < book.max_count && found)
                {
                    book.count++;
                    return true;
                }
            }
            return false;
        }

        public void Add_book(Book book)
        {
            Library.Add_book(book);
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.login))
                errors.Add(new ValidationResult("NO LOGIN NAME!"));
            return errors;
        }


    }
}
