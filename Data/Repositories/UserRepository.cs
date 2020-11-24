using Data.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IDataContext _dataContext;

		public UserRepository(IDataContext context)
		{
			_dataContext = context;
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await _dataContext.Users
				.AsNoTracking()
				.Include(user => user.Ratings)
				.ThenInclude(rating => rating.Movie)
				.Where(user => user.Active)
				.ToListAsync();
		}

		public async Task<User> GetAsync(int id)
		{
			return await _dataContext.Users.FindAsync(id);
		}

		public async Task<User> GetAsync(string login)
		{
			return await _dataContext.Users
				.SingleOrDefaultAsync(user => user.Login.Equals(login));
		}

		public async Task AddAsync(User user)
		{
			_dataContext.Users.Add(user);
			await _dataContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(User user)
		{
			_dataContext.Users.Update(user);
			await _dataContext.SaveChangesAsync();
		}

		public async Task Deactivate(User user)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<User>> GetActiveBasicUsers(int pageIndex = 0, int usersPerPage = 0)
		{
			throw new NotImplementedException();
		}
	}
}
