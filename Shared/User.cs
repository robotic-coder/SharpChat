namespace ChatApplication.Shared
{
	public class User
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Username { get; set; }
		public Tuple<int, int, int> Color { get; set; }

		public User()
		{
			// For serialization. Do not use.
			this.Id = "";
			this.Name = "";
			this.Surname = "";
			this.Username = "";
			this.Color = new Tuple<int, int, int>(0, 0, 0);
		}
		
        public User(string name, string surname, string username)
		{
			this.Id = Guid.NewGuid().ToString();
			this.Name = name;
			this.Surname = surname;
			this.Username = username;

			Random rng = new Random();
			this.Color = new Tuple<int, int, int>(rng.Next(128, 255), rng.Next(128, 255), rng.Next(128, 255)); // Restrict to light colours
		}
	}
}