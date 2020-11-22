namespace Domain
{
	public class Rating
	{
		private Rating(int id, short value)
		{
			Id = id;
			Value = value;
		}

		public Rating(int id, User user, Movie movie, short value)
			: this(id, value)
		{
			User = user;
			Movie = movie;
		}

		public int Id { get; private set; }
		public User User { get; private set; }
		public Movie Movie { get; private set; }
		public short Value { get; private set; }
	}
}
