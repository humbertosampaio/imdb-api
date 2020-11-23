using Domain;
using Service.DTOs.Movie;
using System.Threading.Tasks;

namespace Service.Factories.Interfaces
{
	public interface IMovieFactory
	{
		Task<Movie> CreateAsync(MovieInputDto dto);
	}
}
