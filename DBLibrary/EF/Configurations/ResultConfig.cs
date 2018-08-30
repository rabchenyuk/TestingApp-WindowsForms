using DBLibrary.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBLibrary.EF.Configurations
{
    class ResultConfig : EntityTypeConfiguration<Result>
    {
        public ResultConfig()
        {
            HasKey(k => k.Id);
            Property(ra => ra.CountRightAnswers).IsRequired();
            Property(wa => wa.CountWrongAnswers).IsRequired();
        }
    }
}
