using Service.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
	public interface IUserService
	{
		public Task<IEnumerable<UserOutputDto>> GetAll();
	}
}
