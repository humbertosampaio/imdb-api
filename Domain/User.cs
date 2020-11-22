using System.Collections.Generic;

namespace Domain
{
	public class User
	{
		public User(int id, string name, Role role)
		{
			Id = id;
			Name = name;
			Role = role;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public Role Role { get; private set; }
		public ICollection<Rating> Ratings { get; set; }
	}

	public enum Role : short
	{
		Administrator,
		BasicUser
	}
}
