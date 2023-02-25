using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Umelle24February2023BurakOzenc.Domain;

namespace Umelle24February2023BurakOzenc.Persistence.TableConfigurations;

public class UsersTableConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .ValueGeneratedNever();
        
        builder.Property(e => e.Email)
            .HasMaxLength(244);
        
        builder.Property(e => e.Password)
            .HasMaxLength(30);
    }
}