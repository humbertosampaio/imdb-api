using Service.DTOs.Rating;
using System.Collections.Generic;
using System.Linq;

namespace Service.DTOs.User
{
	public readonly struct UserOutputDto
	{
		public UserOutputDto(int id, string login, IEnumerable<RatingOutputDto> ratings)
		{
			Id = id;
			Login = login;
			Ratings = ratings;
		}

		public UserOutputDto(Domain.User user)
		{
			Id = user.Id;
			Login = user.Login;
			Ratings = user.Ratings.Select(rating => new RatingOutputDto(rating));
		}

		public int Id { get; }
		public string Login { get; }
		public IEnumerable<RatingOutputDto> Ratings { get; }
	}
}