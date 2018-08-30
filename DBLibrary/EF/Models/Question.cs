using System;
using System.Collections.Generic;

namespace DBLibrary.EF.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }

        public override string ToString()
        {
            return string.Format(Convert.ToString(Id));
        }
    }
}
