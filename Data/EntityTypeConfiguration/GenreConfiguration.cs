using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
	public class GenreConfiguration : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			builder.HasIndex(genre => genre.Name).IsUnique();
			builder.HasMany(genre => genre.Movies).WithOne(movie => movie.Genre);

			builder.Property(genre => genre.Id)
				.UseIdentityColumn();

			builder.Property(genre => genre.Name)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnType("varchar(50)");
		}
	}
}
