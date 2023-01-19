using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DDDInheritance.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class DDDInheritanceDbContextFactory : IDesignTimeDbContextFactory<DDDInheritanceDbContext>
{
    public DDDInheritanceDbContext CreateDbContext(string[] args)
    {
        DDDInheritanceEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<DDDInheritanceDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new DDDInheritanceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DDDInheritance.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
