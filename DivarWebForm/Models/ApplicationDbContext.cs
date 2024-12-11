using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DivarWebForm.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DivarConnection") { }

        public DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advertisement>()
                .HasRequired(a => a.User)
                .WithMany(u => u.Advertisements)
                .HasForeignKey(a => a.UserId);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
