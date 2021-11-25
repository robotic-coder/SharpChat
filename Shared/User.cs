namespace ChatApplication.Shared
{
	public class MinifiedUser
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public Tuple<int, int, int> Color { get; set; }

		public MinifiedUser()
		{
			// For serialization. Do not use.
			this.Id = "";
			this.Username = "";
			this.Color = new Tuple<int, int, int>(0, 0, 0);
		}
		
        public MinifiedUser(string username)
		{
			this.Id = Guid.NewGuid().ToString();
			this.Username = username;

			Random rng = new Random();
			this.Color = new Tuple<int, int, int>(rng.Next(128, 255), rng.Next(128, 255), rng.Next(128, 255)); // Restrict to light colours
		}
	}
    public class User: MinifiedUser
    {
		public string LoginKey { get; }
		public string Name { get; }
		public string Surname { get; }
		
        public User(string name, string surname, string username): base(username)
		{
			this.LoginKey = Guid.NewGuid().ToString();
			this.Name = name;
			this.Surname = surname;
		}
    }
}