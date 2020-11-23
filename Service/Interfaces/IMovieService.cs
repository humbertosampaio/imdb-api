﻿using Data.Repositories.Filters;
using Domain;
using Service.DTOs.Movie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
	public interface IMovieService
	{
		Task AddAsync(MovieInputDto movieInputDto);
		Task AddRating(User user, int rating);
		Task<IEnumerable<Movie>> Get(MovieFilterDto filter, int pageIndex = 0, int usersPerPage = 0);
	}
}