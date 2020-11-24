using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasIndex(user => user.Login).IsUnique();
			builder.HasMany(user => user.Ratings).WithOne(rating => rating.User);

			builder.Property(e => e.Id)
				.UseIdentityColumn();

			builder.Property(user => user.Login)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnType("varchar(50)");

			builder.Property(user => user.Role)
				.IsRequired()
				.HasComment("1. Administrator; 2. BasicUser");

			builder.Property(user => user.Active)
				.IsRequired()
				.HasDefaultValue(true);
		}
	}
}
