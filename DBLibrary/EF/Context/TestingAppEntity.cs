namespace DBLibrary.EF.Context
{
    using DBLibrary.EF.Configurations;
    using DBLibrary.EF.Models;
    using System.Data.Entity;

    public class TestingAppEntities : DbContext
    {
        static TestingAppEntities()
        {
            Database.SetInitializer<TestingAppEntities>(new MyContextInitializer());
        }

        public TestingAppEntities()
            : base("name=TestingAppEntity")
        {
            //Database.SetInitializer(
            //    new DropCreateDatabaseIfModelChanges<TestingAppEntities>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new QuestionConfig());
            modelBuilder.Configurations.Add(new AnswerConfig());
            modelBuilder.Configurations.Add(new ResultConfig());
        }
    }
}