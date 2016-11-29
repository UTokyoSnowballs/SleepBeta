namespace SleepMakeSense.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    // 20161107 Pandita
    using System.Security.Claims;
    using System.Threading.Tasks;

    // Pandita: why partial class??
    public partial class Database : DbContext
    {
        internal object DiaryData;

        /* 20161107 Pandita
public Database()
: base("name=Database")
{
}
*/

        public Database()
    : base("Database")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TokenManagement> TokenManagements { get; set; }
        public virtual DbSet<Userdata> Userdatas { get; set; }
        public virtual DbSet<UserQuestion> UserQuestions { get; set; }
        public virtual DbSet<FitbitData> FitbitDatas { get; set; }
        public virtual DbSet<DiaryData> DiaryDatas { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

        }

        // 20161107 Pandita: define Create() and SaveChanges()
        public static Database Create()
        {
            return new Database();
        }

        internal void SaveChanges(int id)
        {
            throw new NotImplementedException();
        }
    }
}
