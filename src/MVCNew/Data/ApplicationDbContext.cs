using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MVCNew.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      foreach (var entity in builder.Model.GetEntityTypes())
      {
        // Replace table names
        entity.SetTableName(ToSnakeCase(entity.GetTableName()));

        // Replace column names            
        foreach (var property in entity.GetProperties())
        {
          property.SetColumnName(ToSnakeCase(property.GetColumnName()));
        }

        foreach (var key in entity.GetKeys())
        {
          key.SetName(ToSnakeCase(key.GetName()));
        }

        foreach (var key in entity.GetForeignKeys())
        {
          key.SetConstraintName(ToSnakeCase(key.GetDefaultName()));
        }

        foreach (var index in entity.GetIndexes())
        {
          index.SetDatabaseName(ToSnakeCase(index.GetDatabaseName()));
        }
      }
      builder.Entity<IdentityUser>().ToTable("users");
      builder.Entity<IdentityRole>().ToTable("roles");
      builder.Entity<IdentityUserRole<string>>().ToTable("user_roles");
      builder.Entity<IdentityRoleClaim<string>>().ToTable("role_claims");
      builder.Entity<IdentityUserClaim<string>>().ToTable("user_claims");
      builder.Entity<IdentityUserToken<string>>().ToTable("user_tokens");
      builder.Entity<IdentityUserLogin<string>>().ToTable("user_logins");
      Seed(builder);
      
    }

    private void Seed(ModelBuilder builder)
    {
      var role = new IdentityRole("admin");
      var admin = new IdentityUser("admin");
      admin.NormalizedUserName = admin.UserName;
      admin.Email = admin.NormalizedEmail = "admin@gmail.com";
      admin.EmailConfirmed = true;
      admin.PhoneNumber = "0987654321";

      builder.Entity<IdentityRole>().HasData(role);
      builder.Entity<IdentityUser>().HasData(admin);

      var passwordHasher = new PasswordHasher<IdentityUser>();
      admin.PasswordHash = passwordHasher.HashPassword(admin, "its@2022");

      var assignRole = new IdentityUserRole<string>
      {
        UserId = admin.Id,
        RoleId = role.Id
      };
      builder.Entity<IdentityUserRole<string>>().HasData(assignRole);
    }

    private string ToSnakeCase(string input)
    {
      if (string.IsNullOrEmpty(input)) { return input; }

      var startUnderscores = Regex.Match(input, @"^_+");
      return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }
  }
}