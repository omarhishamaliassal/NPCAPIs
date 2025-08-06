using Microsoft.EntityFrameworkCore;
using NPCAPIs.Models; 

namespace NPCAPIs.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

      
        public DbSet<NewsAPI> News { get; set; }
        
        
        public DbSet<VGovStatAPI> VGovStat { get; set; }

        public DbSet<VActiveEmpAPI> VActiveEmp { get; set; }
        public DbSet<AboutAPI> About { get; set; }
        public DbSet<VideoLibraryAPI> VideoLibrary { get; set; }
        public DbSet<AwarenessMsgAPI> AwarenessMsg { get; set; }
        public DbSet<ImportantLinksAPI> ImportantLinks { get; set; }
        public DbSet<InfographAPI> Infograph { get; set; }
        public DbSet<InitiativeNumbersAPI> InitiativeNumbers { get; set; }
        public DbSet<CommonQuestionAPI> CommonQuestion { get; set; }
        public DbSet<ContactUsAPI> ContactUs { get; set; }
        public DbSet<VPhotoesAPI> VPhotoes { get; set; }
        public DbSet<VIndicatorsAPI> VIndicators { get; set; }
        public DbSet<VServicesAPI> VServices { get; set; }
        public DbSet<LkpMashoraTypeAPI> LkpMashoraType { get; set; }
        public DbSet<OpinionAPI> Opinion { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<LkpQualification> LkpQualifications { get; set; }
        public DbSet<Regestration> Regestrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure VGovStat as a view with no key (read-only)
            modelBuilder.Entity<VGovStatAPI>().HasNoKey().ToView("VGovStat");
            modelBuilder.Entity<VActiveEmpAPI>().HasNoKey().ToView("VActiveEmp");
            modelBuilder.Entity<VPhotoesAPI>().HasNoKey().ToView("VPhotoes");
            modelBuilder.Entity<VServicesAPI>().HasNoKey().ToView("VServices");
            modelBuilder.Entity<VIndicatorsAPI>().HasNoKey().ToView("VIndicators");
            modelBuilder.Entity<TeamMember>()
               .HasOne(tm => tm.Qualification)
               .WithMany(q => q.TeamMembers)
               .HasForeignKey(tm => tm.QualificationId);
            modelBuilder.Entity<Regestration>()
         .HasOne(tm => tm.Qualification)
         .WithMany(q => q.Regestrations)
         .HasForeignKey(tm => tm.QualificationId);
        }
    }
}
