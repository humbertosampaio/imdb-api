using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public static class ControllerBaseExtensions
	{
		[HttpGet]
		public static ObjectResult InternalServerError(this ControllerBase controller, string errorMessage = "Unexpected error.")
		{
			return controller.StatusCode(500, errorMessage);
		}
	}
}
