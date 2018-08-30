using DBLibrary.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBLibrary.EF.Configurations
{
    class QuestionConfig : EntityTypeConfiguration<Question>
    {
        public QuestionConfig()
        {
            HasKey(k => k.Id);
            Property(t => t.Text).IsRequired().IsMaxLength();

            HasMany(a => a.Answers)
                .WithRequired(q => q.Question)
                .HasForeignKey(fk => fk.QuestionId);
        }
    }
}
