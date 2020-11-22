using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
	public class ActorConfiguration : IEntityTypeConfiguration<Actor>
	{
		public void Configure(EntityTypeBuilder<Actor> builder)
		{
			builder.HasIndex(actor => actor.Name).IsUnique();
			builder.HasMany(actor => actor.Movies).WithMany(movie => movie.Actors);

			builder.Property(actor => actor.Id)
				.UseIdentityColumn();

			builder.Property(actor => actor.Name)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");
		}
	}
}
