using Data.DTOs;
using Data.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
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

		public async Task<IEnumerable<User>> GetActiveBasicUsersAsync(PaginationDto paginationDto)
		{
			IQueryable<User> users = _dataContext.Users
				.AsNoTracking()
				.Include(user => user.Ratings)
				.ThenInclude(rating => rating.Movie)
				.Where(user => user.Active && user.Role.Equals(RoleEnum.BasicUser))
				.OrderBy(user => user.Login);

			if (paginationDto.EnablePagination)
				users = users
					.Skip(paginationDto.RegistersPerPage * (paginationDto.PageNumber - 1))
					.Take(paginationDto.RegistersPerPage);

			return await users.ToListAsync();
		}

		public async Task<User> GetAsync(int id, bool asNoTracking = false)
		{
			IQueryable<User> users = _dataContext.Users;

			if (asNoTracking)
				users = users.AsNoTracking();

			return await users.SingleAsync(user => user.Id.Equals(id));
		}

		public async Task<User> GetAsync(string login, bool asNoTracking = false)
		{
			IQueryable<User> users = _dataContext.Users;

			if (asNoTracking)
				users = users.AsNoTracking();

			return await users.SingleAsync(user => user.Login.Equals(login));
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
	}
}
