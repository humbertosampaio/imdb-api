using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public abstract class BaseApiController : ControllerBase
	{
		public virtual ObjectResult InternalServerError(string detail = "Unexpected error.")
		{
			return Problem(detail, statusCode: 500);
		}
	}
}
