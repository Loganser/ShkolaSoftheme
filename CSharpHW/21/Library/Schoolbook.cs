using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    [Serializable]
    [OnlyForViewing]
    public class Schoolbook : Literature
    {

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string School;
        public Schoolbook(string title, string author_name, string school, int year, int pages, int count) : base(title, author_name, year, pages, count)
        {
            this.School = school;
        }
        public Schoolbook()
        {
            this.School = "";
        }
    }
}
