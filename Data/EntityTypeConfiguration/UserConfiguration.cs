using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasMany(user => user.Ratings).WithOne(rating => rating.User);

			builder.Property(e => e.Id)
				.UseIdentityColumn();

			builder.Property(user => user.Name)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(user => user.Role)
				.IsRequired()
				.HasComment("1. Administrator; 2. BasicUser");
		}
	}
}
