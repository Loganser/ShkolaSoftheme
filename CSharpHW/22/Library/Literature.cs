using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Library
{
    [DataContract]
    [Serializable]
    [XmlInclude(typeof(Book))]
    [XmlInclude(typeof(Schoolbook))]
    public class Literature : IValidatableObject
    {
        [DataMember]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string title { get; set; }
        [DataMember]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string author_name { get; set; }
        [DataMember]
        [Required]
        public int year { get; set; }
        [DataMember]
        [Required]
        public int pages { get; set; }
        [DataMember]
        [Required]
        public int pop_index { get; set; }
        [DataMember]
        [Required]
        public int max_count { get; set; }
        [DataMember]
        [Required]
        public int count { get; set; }
        [DataMember]
        [Required]
        public string last_taken_by { get; set; }

        public Literature(string title, string author_name, int year, int pages, int count)
        {
            this.title = title;
            this.year = year;
            this.pages = pages;
            this.pop_index = 0;
            this.author_name = author_name;
            this.count = this.max_count = count;
            this.last_taken_by = "no one";
        }

        public Literature()
        {
            this.title = "";
            this.year = 0;
            this.pages = 0;
            this.pop_index = 0;
            this.author_name = "";
            this.count = this.max_count = 0;
            this.last_taken_by = "no one";
        }

        public void Change_last_user(string user_name)
        {
            last_taken_by = user_name;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.title))
                errors.Add(new ValidationResult("NO TITLE!"));
            if (string.IsNullOrWhiteSpace(this.author_name))
                errors.Add(new ValidationResult("NO AUTHOR!"));
            if (year < 1 || year > 5000)
                errors.Add(new ValidationResult("INCORRECT YEAR!"));
            if (pages < 1 || pages > 100500)
                errors.Add(new ValidationResult("INCORRECT NUMBER OF PAGES!"));
            return errors;
        }
    }
}
