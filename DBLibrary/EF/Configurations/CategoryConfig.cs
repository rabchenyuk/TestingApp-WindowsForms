using DBLibrary.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBLibrary.EF.Configurations
{
    class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            HasKey(k => k.Id);
            Property(tn => tn.TestName).IsRequired().HasMaxLength(255);

            HasMany(q => q.Questions)
                .WithRequired(c => c.Category)
                .HasForeignKey(fk => fk.CategoryId);
        }
    }
}
