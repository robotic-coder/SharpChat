namespace ChatApplication.Shared
{
    public class Message
    {
		public string? Id { get; set; }
		public bool? IsSystem { get; set; }
		public string? Sender { get; set; }
		public string? Text { get; set; }
		public Tuple<int, int, int>? Color { get; set; }
		public DateTime? Timestamp { get; set; }

		public Message()
		{
			// Empty constructor for serialization
		}
		
        protected Message(bool isSystem, string sender, string text, Tuple<int, int, int> color)
		{
			Id = Guid.NewGuid().ToString();
			IsSystem = isSystem;
			Sender = sender;
			Text = text;
			Color = color;
			Timestamp = DateTime.Now;
		}
    }

	public class SystemMessage: Message
	{
		public SystemMessage(string messageContent): base(true, "System", messageContent, new Tuple<int, int, int>(255, 0, 0))
		{
			
		}
	}

	public class UserMessage: Message
	{
		public UserMessage(User sender, string messageContent): base(false, sender.Username, messageContent, sender.Color)
		{

		}
	}
}