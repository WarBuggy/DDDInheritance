using DDDInheritance.Commons;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using DDDInheritance.CommonEntities;
using DDDInheritance.Alphas;
using DDDInheritance.Betas;

namespace DDDInheritance.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class DDDInheritanceDbContext :
    AbpDbContext<DDDInheritanceDbContext>,
    IIdentityProDbContext,
    ISaasDbContext
{
    public DbSet<Common> Commons { get; set; }
    public DbSet<Alpha> Alphas { get; set; }
    public DbSet<Beta> Betas { get; set; }
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<CommonEntity> CommonEntities { get; set; }
    public DbSet<Alpha> Alphas { get; set; }
    public DbSet<Beta> Betas { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // SaaS
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DDDInheritanceDbContext(DbContextOptions<DDDInheritanceDbContext> options)
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
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureLanguageManagement();
        builder.ConfigureSaas();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureGdpr();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(DDDInheritanceConsts.DbTablePrefix + "YourEntities", DDDInheritanceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<CommonEntity>(b =>
        {
            b.UseTpcMappingStrategy();
            //b.ToTable(DDDInheritanceConsts.DbTablePrefix + "Commons", DDDInheritanceConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.TenantId).HasColumnName(nameof(CommonEntity.TenantId));
            b.Property(x => x.Code).HasColumnName(nameof(CommonEntity.Code)).IsRequired().HasMaxLength(CommonEntityConsts.CodeMaxLength);
            b.Property(x => x.Name).HasColumnName(nameof(CommonEntity.Name)).HasMaxLength(CommonEntityConsts.NameMaxLength);
            b.Property(x => x.Status).HasColumnName(nameof(CommonEntity.Status));
            b.Property(x => x.Linked).HasColumnName(nameof(CommonEntity.Linked));
        });
    }
}