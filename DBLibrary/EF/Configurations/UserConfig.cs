using System.Data.Entity.ModelConfiguration;
using DBLibrary.EF.Models;

namespace DBLibrary.EF.Configurations
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasKey(k => k.Id);
            Property(fn => fn.FirstName).IsRequired().HasMaxLength(100);
            Property(ln => ln.LastName).IsRequired().HasMaxLength(100);
            Property(e => e.Email).IsRequired();
            Property(l => l.Login).IsRequired().HasMaxLength(50);
            Property(p => p.Password).IsRequired().HasMaxLength(10);
        }
    }
}
