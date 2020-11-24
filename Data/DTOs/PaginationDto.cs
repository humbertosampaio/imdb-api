using Newtonsoft.Json;

namespace Data.DTOs
{
	public struct PaginationDto
	{
		[JsonConstructor]
		public PaginationDto(bool enablePagination, int pageNumber, int registersPerPage)
		{
			EnablePagination = enablePagination;
			PageNumber = pageNumber == 0 ? 1 : pageNumber;
			RegistersPerPage = registersPerPage == 0 ? 10 : registersPerPage;
		}

		public bool EnablePagination { get; set; }
		public int PageNumber { get; set; }
		public int RegistersPerPage { get; set; }
	}
}
