using Data;
using Data.Repositories.Interfaces;
using Domain;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class RatingRepository : IRatingRepository
	{
		private readonly IDataContext _dataContext;

		public RatingRepository(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task AddAsync(Rating rating)
		{
			_dataContext.Ratings.Add(rating);
			await _dataContext.SaveChangesAsync();
		}
	}
}
