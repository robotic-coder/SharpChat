namespace ChatApplication.Shared
{
    public class Message
    {
		public string? Id { get; set; }
		public string? SenderName { get; set; }
		public string? SenderId { get; set; }
		public string? Text { get; set; }
		public Tuple<int, int, int>? Color { get; set; }
		public DateTime? Timestamp { get; set; }

		public Message()
		{
			// Empty constructor for serialization
		}
		
        protected Message(string? senderID, string senderName, string text, Tuple<int, int, int> color)
		{
			this.Id = Guid.NewGuid().ToString();
			this.SenderId = senderID;
			this.SenderName = senderName;
			this.Text = text;
			this.Color = color;
			this.Timestamp = DateTime.Now;
		}

		public bool IsFromSender(string senderID)
		{
			return this.SenderId == senderID;
		}
    }

	public class SystemMessage: Message
	{
		public SystemMessage(string messageContent): base(null, "System", messageContent, new Tuple<int, int, int>(255, 0, 0))
		{
			
		}
	}

	public class UserMessage: Message
	{
		public UserMessage(User sender, string messageContent): base(sender.Id, sender.Username, messageContent, sender.Color)
		{

		}
	}
}