using Microsoft.EntityFrameworkCore;
using NPCAPIs.Models; // ✅ Ensure this matches the actual namespace of your models

namespace NPCAPIs.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ✅ DbSets for your tables
        public DbSet<NewsAPI> News { get; set; }
        
        
        public DbSet<VGovStatAPI> VGovStat { get; set; }

        public DbSet<VActiveEmpAPI> VActiveEmp { get; set; }
        public DbSet<AboutAPI> About { get; set; }
        public DbSet<VideoLibraryAPI> VideoLibrary { get; set; }
        public DbSet<AwarenessMsgAPI> AwarenessMsg { get; set; }
        public DbSet<ImportantLinksAPI> ImportantLinks { get; set; }
        public DbSet<InfographAPI> Infograph { get; set; }
        public DbSet<InitiativeNumbersAPI> InitiativeNumbers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure VGovStat as a view with no key (read-only)
            modelBuilder.Entity<VGovStatAPI>().HasNoKey().ToView("VGovStat");
            modelBuilder.Entity<VActiveEmpAPI>().HasNoKey().ToView("VActiveEmp");
        }
    }
}
