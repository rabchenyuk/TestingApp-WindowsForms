using DBLibrary.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBLibrary.EF.Configurations
{
    class AnswerConfig : EntityTypeConfiguration<Answer>
    {
        public AnswerConfig()
        {
            HasKey(k => k.Id);
            Property(t => t.Text).IsRequired().HasMaxLength(255);
            Property(b => b.IsTrue).IsRequired();
        }
    }
}
