using Data.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IDataContext _context;

		public UserRepository(IDataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await _context.Users
				.Include(user => user.Ratings)
				.ThenInclude(rating => rating.Movie)
				.ToListAsync();
		}

		public async Task<User> Get(int id)
		{
			throw new NotImplementedException();
		}

		public async Task Insert(User user)
		{
			throw new NotImplementedException();
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
