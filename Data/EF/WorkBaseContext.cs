namespace Data.EF
{
    using System.Data.Entity;
    using Data.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data.Identity.Entities;

    public partial class WorkBaseContext : IdentityDbContext<ApplicationUser>
    {
        public WorkBaseContext(string connectionString)
            : base(connectionString)
        {
        }

        static WorkBaseContext()
        {
            Database.SetInitializer((new DbInitializaer()));
        }

        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<ResumesExperience> ResumesExperiences { get; set; }
        public virtual DbSet<Rubric> Rubrics { get; set; }
        public virtual DbSet<User> UsersProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

    public class DbInitializaer : DropCreateDatabaseIfModelChanges<WorkBaseContext>
    {
        protected override void Seed(WorkBaseContext context)
        {
            string[] commands =
            {
                @"INSERT INTO [dbo].[AspNetRoles] ([Id] ,[Name] ,[Discriminator]) VALUES ('9c39f82e-c87b-4bfb-b786-eec87ac45744','admin','ApplicationRole')",
                @"INSERT INTO [dbo].[AspNetRoles] ([Id] ,[Name] ,[Discriminator]) VALUES ('3b25e968-41c8-48cd-bd65-7f235b5c209e','user','ApplicationRole')",
                @"INSERT INTO [dbo].[AspNetRoles] ([Id] ,[Name] ,[Discriminator]) VALUES ('cb25e968-4dc8-48cd-ac65-7f230a5c209e','moderator','ApplicationRole')",
                @"INSERT INTO [dbo].[AspNetUsers] ([Id] ,[Email] ,[EmailConfirmed] ,[PasswordHash] ,[SecurityStamp] ,[PhoneNumber] ,[PhoneNumberConfirmed] ,[TwoFactorEnabled],[LockoutEndDateUtc] ,[LockoutEnabled] ,[AccessFailedCount] ,[UserName]) 
                    VALUES ('f0e55c71-2e6c-41df-bea1-1ff5dc102f59' ,'admin@gmail.com' ,0 ,'AGWw56+JXBJWPXED3BLTjDmPM5/166S/TuwnjGG842sBb1a967GidG+05UWJRukNXw==' ,'1c52b5dd-622b-47a6-b426-46e4751c548b',NULL ,0 ,0 ,NULL ,0 ,0 ,'admin@gmail.com')", //password = "adminpassword"
                @"INSERT INTO [dbo].[Users] ([Id], [Name]) VALUES ('f0e55c71-2e6c-41df-bea1-1ff5dc102f59', 'Admin')",
                @"INSERT INTO [dbo].[AspNetUserRoles] ([UserId] ,[RoleId]) VALUES ('f0e55c71-2e6c-41df-bea1-1ff5dc102f59', '9c39f82e-c87b-4bfb-b786-eec87ac45744')",
                @"INSERT INTO [dbo].[Categories] ([Name]) VALUES ('Other')"
            };

            foreach (var el in commands)
                context.Database.ExecuteSqlCommand(el);

            context.SaveChanges();
        }
    }
}
