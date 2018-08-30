using System;
using System.Collections.Generic;

namespace DBLibrary.EF.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string TestName { get; set; }

        public ICollection<Question> Questions { get; set; }
        public Category()
        {
            Questions = new List<Question>();
        }

        public override string ToString()
        {
            return string.Format(Convert.ToString(Id));
        }
    }
}
