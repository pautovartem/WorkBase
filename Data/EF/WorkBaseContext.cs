namespace Data.EF
{
    using System.Data.Entity;
    using Data.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Identity.Entities;

    public partial class WorkBaseContext : IdentityDbContext<ApplicationUser>
    {
        public WorkBaseContext(string connectionString)
            : base("name=WorkBaseConnectionString")
        {
        }

        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<ResumesExperience> ResumesExperiences { get; set; }
        public virtual DbSet<Rubric> Rubrics { get; set; }
        public virtual DbSet<User> UsersProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Career>()
                .HasMany(e => e.Offers)
                .WithRequired(e => e.Career)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resume>()
                .Property(e => e.Payment)
                .IsFixedLength();

            modelBuilder.Entity<Resume>()
                .HasMany(e => e.Offers)
                .WithRequired(e => e.Resume)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resume>()
                .HasMany(e => e.ResumesExperiences)
                .WithRequired(e => e.Resume)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rubric>()
                .HasMany(e => e.Careers)
                .WithRequired(e => e.Rubric)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rubric>()
                .HasMany(e => e.Resumes)
                .WithRequired(e => e.Rubric)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Careers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Resumes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

        }
    }
}
