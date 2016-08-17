namespace SleepMakeSense.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TokenManagement> TokenManagements { get; set; }
        public virtual DbSet<UniqueURL> UniqueURLs { get; set; }
        public virtual DbSet<Userdata> Userdatas { get; set; }
        public virtual DbSet<UserQuestion> UserQuestions { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<ActiveSubscription> ActiveSubscriptions { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<CachePolicy> CachePolicies { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<ChunkData> ChunkDatas { get; set; }
        public virtual DbSet<ChunkSegmentMapping> ChunkSegmentMappings { get; set; }
        public virtual DbSet<ConfigurationInfo> ConfigurationInfoes { get; set; }
        public virtual DbSet<DataSet> DataSets { get; set; }
        public virtual DbSet<DataSource> DataSources { get; set; }
        public virtual DbSet<DBUpgradeHistory> DBUpgradeHistories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<ExecutionLog> ExecutionLogs { get; set; }
        public virtual DbSet<ExecutionLog2> ExecutionLog2 { get; set; }
        public virtual DbSet<ExecutionLog3> ExecutionLog3 { get; set; }
        public virtual DbSet<ExecutionLogStorage> ExecutionLogStorages { get; set; }
        public virtual DbSet<ExtendedDataSet> ExtendedDataSets { get; set; }
        public virtual DbSet<ExtendedDataSource> ExtendedDataSources { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Key> Keys { get; set; }
        public virtual DbSet<ModelDrill> ModelDrills { get; set; }
        public virtual DbSet<ModelItemPolicy> ModelItemPolicies { get; set; }
        public virtual DbSet<ModelPerspective> ModelPerspectives { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyUserRole> PolicyUserRoles { get; set; }
        public virtual DbSet<ReportSchedule> ReportSchedules { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RunningJob> RunningJobs { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<SecData> SecDatas { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<SegmentedChunk> SegmentedChunks { get; set; }
        public virtual DbSet<ServerParametersInstance> ServerParametersInstances { get; set; }
        public virtual DbSet<ServerUpgradeHistory> ServerUpgradeHistories { get; set; }
        public virtual DbSet<SnapshotData> SnapshotDatas { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SubscriptionsBeingDeleted> SubscriptionsBeingDeleteds { get; set; }
        public virtual DbSet<UpgradeInfo> UpgradeInfoes { get; set; }
        public virtual DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Userdatas)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Batch>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<ExecutionLog2>()
                .Property(e => e.RequestType)
                .IsUnicode(false);

            modelBuilder.Entity<ExecutionLog2>()
                .Property(e => e.ReportAction)
                .IsUnicode(false);

            modelBuilder.Entity<ExecutionLog2>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<ExecutionLog3>()
                .Property(e => e.RequestType)
                .IsUnicode(false);

            modelBuilder.Entity<ExecutionLog3>()
                .Property(e => e.ItemAction)
                .IsUnicode(false);

            modelBuilder.Entity<ExecutionLog3>()
                .Property(e => e.Source)
                .IsUnicode(false);
        }
    }
}
