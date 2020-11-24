using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public abstract class BaseApiController : ControllerBase
	{
		public virtual ObjectResult InternalServerError(string errorMessage = "Unexpected error.")
		{
			return StatusCode(500, errorMessage);
		}
	}
}
