﻿using Data.DTOs;
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
			return await _dataContext.Users
				.AsNoTracking()
				.Include(user => user.Ratings)
				.ThenInclude(rating => rating.Movie)
				.Where(user => user.Active && user.Role.Equals(RoleEnum.BasicUser))
				.OrderBy(user => user.Login)
				.Skip(paginationDto.RegistersPerPage * (paginationDto.PageNumber - 1))
				.Take(paginationDto.RegistersPerPage)
				.ToListAsync();
		}

		public async Task<User> GetAsync(int id)
		{
			return await _dataContext.Users
				.AsNoTracking()
				.SingleAsync(user => user.Id.Equals(id));
		}

		public async Task<User> GetAsync(string login)
		{
			return await _dataContext.Users
				.AsNoTracking()
				.SingleAsync(user => user.Login.Equals(login));
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
