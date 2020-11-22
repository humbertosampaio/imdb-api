using System.Collections.Generic;
using System.Linq;

namespace Service.DTOs.User
{
	public struct UserOutputDto
	{
		public UserOutputDto(int id, string name, IEnumerable<RatingOutputDto> ratings)
		{
			Id = id;
			Name = name;
			Ratings = ratings;
		}

		public UserOutputDto(Domain.User user)
		{
			Id = user.Id;
			Name = user.Name;
			Ratings = user.Ratings.Select(rating => new RatingOutputDto(rating));
		}

		public int Id { get; }
		public string Name { get; }
		public IEnumerable<RatingOutputDto> Ratings { get; }
	}
}
