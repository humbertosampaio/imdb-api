namespace Service.DTOs.Rating
{
	public struct RatingOutputDto
	{
		/// <exception cref="System.NullReferenceException">If <see cref="Rating.Movie"/> in parameter <paramref name="rating"/> is <see cref="true"/></exception>
		public RatingOutputDto(Domain.Rating rating)
		{
			MovieId = rating.Movie.Id;
			Value = rating.Value;
		}

		public int MovieId { get; }
		public int Value { get; }
	}
}
