using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EncryptedColumns.DataAccess;

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserId).HasDefaultValueSql("(newid())");
        builder.Property(x => x.SocialSecurityNumber).HasMaxLength(11);
    }
}

