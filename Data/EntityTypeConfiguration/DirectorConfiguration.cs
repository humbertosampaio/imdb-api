using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
	public class DirectorConfiguration : IEntityTypeConfiguration<Director>
	{
		public void Configure(EntityTypeBuilder<Director> builder)
		{
			builder.HasIndex(director => director.Name).IsUnique();
			builder.HasMany(director => director.Movies).WithMany(movie => movie.Directors);

			builder.Property(director => director.Id)
				.UseIdentityColumn();

			builder.Property(director => director.Name)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");
		}
	}
}
