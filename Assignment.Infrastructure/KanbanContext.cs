namespace Assignment.Infrastructure;

public partial class KanbanContext : DbContext
{
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<WorkItem> WorkItems { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public KanbanContext(DbContextOptions<KanbanContext> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=Assignment4-BDSA;Username=Turid;Password=Hej123");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();

        modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                //Name: string(50), required, unique
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Name).IsUnique();

                //WorkItems: many-to-many reference to WorkItem entity
                entity.HasMany(e => e.WorkItems)
                        .WithMany(e => e.Tags)
                        .UsingEntity(e => e.ToTable("TaskTags"));
            });

        modelBuilder.Entity<WorkItem>(entity =>
            {
                entity.ToTable("WorkItem");

                //Title : string(100), required
                entity.Property(e => e.Title).HasMaxLength(100).IsRequired();

                //AssignedTo : optional reference to User entity
                entity.Property(e => e.AssignedTo);

                //Description : string(max), optional
                entity.Property(e => e.Description).HasMaxLength(Int32.MaxValue);

                //State : enum (New, Active, Resolved, Closed, Removed), required
                entity.Property(e => e.State)
                        .IsRequired()
                        .HasConversion(
                        v => v.ToString(),
                        v => (State)Enum.Parse(typeof(State), v));

                //Tags : many-to-many reference to Tag entity*/
                /*entity.HasMany(e => e.Tags)
                        .WithMany(e => e.WorkItems)
                        .UsingEntity(e => e.ToTable("TaskTags"));*/
            });


        modelBuilder.Entity<User>(entity => 
        {
            entity.ToTable("User");

            //Name : string(100), required
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();

            //Email : string(100), required, unique
            entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();

            //WorkItems : list of WorkItem entities belonging to User*/
            entity.HasMany(e => e.WorkItems);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
