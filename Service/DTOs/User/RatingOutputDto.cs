using Domain;

namespace Service.DTOs.User
{
	public struct RatingOutputDto
	{
		public RatingOutputDto(int movieId, int value)
		{
			MovieId = movieId;
			Value = value;
		}

		/// <exception cref="System.NullReferenceException">If <see cref="Rating.Movie"/> in parameter <paramref name="rating"/> is <see cref="true"/></exception>
		public RatingOutputDto(Rating rating)
		{
			MovieId = rating.Movie.Id;
			Value = rating.Value;
		}

		public int MovieId { get; }
		public int Value { get; }
	}
}
