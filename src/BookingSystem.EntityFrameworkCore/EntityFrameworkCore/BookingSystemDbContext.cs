using BookingSystem.BookingSystem;
using BookingSystem.BookingSystem.Branches;
using BookingSystem.BookingSystem.BranchesShared;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace BookingSystem.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class BookingSystemDbContext :
    AbpDbContext<BookingSystemDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<Branch> Branches { get; set; }
    public DbSet<BranchDateSchedule> BranchDateSchedules { get; set; }
    public DbSet<BranchTimeSchedule> BranchTimeSchedules { get; set; }

    public DbSet<CustomField> CustomFields  { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBranch> ProductBranches { get; set; }
    public DbSet<ProductDateSchedule>  ProductDateSchedules { get; set; }
    public DbSet<ProductTimeSchedule> ProductTimeSchedules { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(BookingSystemConsts.DbTablePrefix + "YourEntities", BookingSystemConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        // Configure the Branch entity
        builder.Entity<Branch>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "Branches", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(b => b.BranchName).IsRequired().HasMaxLength(BranchConsts.MaxNameLength);
            b.Property(b => b.BranchLocation).HasMaxLength(BranchConsts.MaxLocationLength);

            b.HasMany(b => b.BranchDateSchedules)
            .WithOne(bds => bds.Branch)
            .HasForeignKey(bds => bds.BranchId);

            b.HasMany(pb => pb.ProductsBranches)
                .WithOne(pa => pa.Branch)
                .HasForeignKey(pa => pa.BranchId);

        });

        // Configure the BranchDateSchedule entity
        builder.Entity<BranchDateSchedule>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "BranchDateSchedules", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(bds => bds.StartDate).IsRequired();
            b.Property(bds => bds.EndDate);

            b.HasOne(bds => bds.Branch)
            .WithMany(b => b.BranchDateSchedules)
            .HasForeignKey(bds => bds.BranchId);

            b.HasMany(bds => bds.BranchTimeSchedules)
            .WithOne(bts => bts.BranchDateSchedule)
            .HasForeignKey(bts => bts.BranchDateScheduleId);

        });

        // Configure the BranchTimeSchedule entity
        builder.Entity<BranchTimeSchedule>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "BranchTimeSchedules", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(bts => bts.DayOfWeek).IsRequired().HasMaxLength(BranchConsts.MaxDayLength);
            b.Property(bts => bts.IsWorkingDay).IsRequired();
            b.Property(bts => bts.OpeningTime);
            b.Property(bts => bts.ClosingTime);
            b.Property(bts => bts.Description);

            b.HasOne(bts => bts.BranchDateSchedule)
            .WithMany(bds => bds.BranchTimeSchedules)
            .HasForeignKey(bts => bts.BranchDateScheduleId);
            
        });

        // Configure the CustomField entity
        builder.Entity<CustomField>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "CustomFields", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();
            
            // Define properties
            b.Property(cf => cf.ProductBranchId).IsRequired();
            b.Property(cf => cf.FieldTitle).HasMaxLength(255).IsRequired(); // Set the desired maximum length
            b.Property(cf => cf.FieldPlaceholder).HasMaxLength(255); // Set the desired maximum length
            b.Property(cf => cf.FieldType).HasMaxLength(50); // Set the desired maximum length
            b.Property(cf => cf.FieldRequired);

            
            // Define relationships
            b.HasOne(cf => cf.ProductBranch)
                .WithMany(pb => pb.CustomFields)
                .HasForeignKey(cf => cf.ProductBranchId)
                .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior
        });

        // Configure the Product entity
        builder.Entity<Product>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "Products", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();

            // Define properties
            b.Property(p => p.ProductName).IsRequired();
            b.Property(p => p.BookingMethod).IsRequired();
            b.Property(p => p.NumberAvailable);
            b.Property(p => p.ClientAppointments);

            // Define relationships 
            b.HasMany(p => p.ProductBranches)
                .WithOne(pb => pb.Product)
                .HasForeignKey(pb => pb.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed
        });

        // Configure the ProductBranch entity
        builder.Entity<ProductBranch>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "ProductBranches", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();

            // Define properties
            b.Property(pb => pb.ProductId).IsRequired();
            b.Property(pb => pb.BranchId).IsRequired();
            b.Property(pb => pb.AvailableBookings).IsRequired();
            b.Property(pb => pb.BookingDuration).IsRequired();
            b.Property(pb => pb.PreparationTime);
            b.Property(pb => pb.OnlineBooking);
            b.Property(pb => pb.ProductPrice);
            
            // Define relationships 
            b.HasOne(pb => pb.Product)
                .WithMany(p => p.ProductBranches)
                .HasForeignKey(pb => pb.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior

            b.HasOne(pb => pb.Branch)
                .WithMany(b => b.ProductsBranches)
                .HasForeignKey(pb => pb.BranchId)
                .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior

            b.HasMany(pb => pb.ProductDateSchedules)
                .WithOne(pds => pds.ProductBranch)
                .HasForeignKey(pds => pds.ProductBranchId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed

            b.HasMany(pb => pb.CustomFields)
                .WithOne(cf => cf.ProductBranch)
                .HasForeignKey(cf => cf.ProductBranchId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed

            b.HasMany(pb => pb.Bookings)
                .WithOne(b => b.ProductBranch)
                .HasForeignKey(b => b.ProductBranchId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed
        });


        // Configure the ProductDateSchedule entity
        builder.Entity<ProductDateSchedule>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "ProductDateSchedules", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();

            // Define properties
            b.Property(pds => pds.ProductBranchId).IsRequired();
            b.Property(pds => pds.StartDate).IsRequired();
            b.Property(pds => pds.EndDate);

            // Define relationships
            b.HasOne(pds => pds.ProductBranch)
                .WithMany(pb => pb.ProductDateSchedules)
                .HasForeignKey(pds => pds.ProductBranchId)
                .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior

            b.HasMany(pds => pds.ProductTimeSchedules)
                .WithOne(pts => pts.ProductDateSchedule)
                .HasForeignKey(pts => pts.ProductDateScheduleId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed
        });

        // Configure the ProductTimeSchedule entity
        builder.Entity<ProductTimeSchedule>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "ProductTimeSchedules", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();
            
            // Define properties
            b.Property(pts => pts.ProductDateScheduleId).IsRequired();
            b.Property(pts => pts.DayOfWeek).IsRequired();
            b.Property(pts => pts.OpeningTime).IsRequired();
            b.Property(pts => pts.ClosingTime).IsRequired();
            b.Property(pts => pts.Description).HasMaxLength(255); // Set the desired maximum length

            // Define relationships
            b.HasOne(pts => pts.ProductDateSchedule)
                .WithMany(pds => pds.ProductTimeSchedules)
                .HasForeignKey(pts => pts.ProductDateScheduleId)
                .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior
        });

        // Configure the Booking entity
        builder.Entity<Booking>(b =>
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "Bookings", BookingSystemConsts.DbSchema);
            b.ConfigureByConvention();

            // Define properties
            b.Property(b => b.ProductBranchId).IsRequired();
            b.Property(b => b.BookingDate).IsRequired();
            b.Property(b => b.BookingStartTime).IsRequired();
            b.Property(b => b.Duration).IsRequired();
            b.Property(b => b.Status).IsRequired();

            // Define relationships
            b.HasOne(b => b.ProductBranch)
                  .WithMany(pb => pb.Bookings)
                  .HasForeignKey(b => b.ProductBranchId)
                  .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate delete behavior

        });
        
    }
}
