namespace Data.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Data.Entities;

    public partial class WorkBaseContext : DbContext
    {
        public WorkBaseContext()
            : base("name=WorkBaseConnectionString")
        {
        }

        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<ResumesExperience> ResumesExperiences { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resume>()
                .Property(e => e.Payment)
                .IsFixedLength();

            modelBuilder.Entity<Resume>()
                .HasMany(e => e.ResumesExperience)
                .WithRequired(e => e.Resumes)
                .HasForeignKey(e => e.ResumeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Resumes)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
