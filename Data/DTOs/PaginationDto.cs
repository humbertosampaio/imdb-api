namespace Data.DTOs
{
	public struct PaginationDto
	{
		public PaginationDto(int pageNumber = 1, int registersPerPage = 10)
		{
			PageNumber = pageNumber;
			RegistersPerPage = registersPerPage;
		}

		public int PageNumber { get; private set; }
		public int RegistersPerPage { get; private set; }
	}
}
