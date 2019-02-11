using System.Data.Entity;
using DataAccessLayer.DataModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccessLayer.Contexts
{
    public class ForumDbContext : IdentityDbContext
    {
        public ForumDbContext() : base("name=ForumDbConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<IdentityUser>().ToTable("USER_INFO");
            modelBuilder.Entity<IdentityRole>().ToTable("ROLE");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("USER_LOGIN");
            modelBuilder.Entity<IdentityUserRole>().ToTable("USER_ROLE");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("USER_CLAIM");

            modelBuilder.Entity<Topic>().ToTable("FORUM_TOPIC");
            modelBuilder.Entity<Post>().ToTable("FORUM_POST");
        }

        public static ForumDbContext Create()
        {
            return new ForumDbContext();
        }
        
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
