namespace ChatApplication.Shared
{
    public class User
    {
		public string Id { get; } = Guid.NewGuid().ToString();
		public string Name { get; }
		public string Surname { get; }
		public string Username { get; }
		public Tuple<int, int, int> Color { get; } = new Tuple<int, int, int>(0, 0, 0);
		
        public User(string name, string surname, string username)
		{
			Name = name;
			Surname = surname;
			Username = username;
		}
    }
}