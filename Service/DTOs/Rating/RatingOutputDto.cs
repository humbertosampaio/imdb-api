namespace Service.DTOs.Rating
{
	public readonly struct RatingOutputDto
	{
		/// <exception cref="System.NullReferenceException">If <see cref="Rating.Movie"/> in parameter <paramref name="rating"/> is <see cref="null"/></exception>
		public RatingOutputDto(Domain.Rating rating)
		{
			MovieName = rating.Movie.Name;
			Value = rating.Value;
		}

		public string MovieName { get; }
		public int Value { get; }
	}
}
