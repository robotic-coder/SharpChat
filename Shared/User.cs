namespace ChatApplication.Shared
{
	public class User
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public string Name { get; }
		public string Surname { get; }
		public Tuple<int, int, int> Color { get; set; }

		public User()
		{
			// For serialization. Do not use.
			this.Id = "";
			this.Username = "";
			this.Name = "";
			this.Surname = "";
			this.Color = new Tuple<int, int, int>(0, 0, 0);
		}
		
        public User(string name, string surname, string username)
		{
			this.Id = Guid.NewGuid().ToString();
			this.Username = username;
			this.Name = name;
			this.Surname = surname;

			Random rng = new Random();
			this.Color = new Tuple<int, int, int>(rng.Next(128, 255), rng.Next(128, 255), rng.Next(128, 255)); // Restrict to light colours
		}
	}
}