using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
	public class MovieConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.HasIndex(movie => movie.Name).IsUnique();
			builder.HasOne(movie => movie.Genre).WithMany(genre => genre.Movies);
			builder.HasMany(movie => movie.Actors).WithMany(actor => actor.Movies);
			builder.HasMany(movie => movie.Directors).WithMany(director => director.Movies);
			builder.HasMany(movie => movie.Ratings).WithOne(rating => rating.Movie);

			builder.Property(movie => movie.Id)
				.UseIdentityColumn();

			builder.Property(movie => movie.Name)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");
		}
	}
}
