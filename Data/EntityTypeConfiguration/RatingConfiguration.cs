using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
	public class RatingConfiguration : IEntityTypeConfiguration<Rating>
	{
		public void Configure(EntityTypeBuilder<Rating> builder)
		{
			builder.HasOne(rating => rating.User).WithMany(user => user.Ratings);
			builder.HasOne(rating => rating.Movie).WithMany(movie => movie.Ratings);

			builder.Property(e => e.Id)
				.UseIdentityColumn();
		}
	}
}
