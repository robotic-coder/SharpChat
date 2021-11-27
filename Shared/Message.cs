namespace ChatApplication.Shared
{
    public class Message
    {
		public string Id { get; set; }
		public User? Sender { get; set; }
		public string Text { get; set; }
		public DateTime Timestamp { get; set; }

		public Message()
		{
			// For serialization. Do not use.
			this.Id = "";
			this.Sender = null;
			this.Text = "";
			this.Timestamp = DateTime.Now;
		}
		
        protected Message(User? sender, string text)
		{
			this.Id = Guid.NewGuid().ToString();
			this.Sender = sender;
			this.Text = text;
			this.Timestamp = DateTime.Now;
		}
    }

	public class SystemMessage: Message
	{
		public SystemMessage(string messageContent): base(null, messageContent)
		{
			
		}
	}

	public class UserMessage: Message
	{
		public UserMessage(User sender, string messageContent): base(sender, messageContent)
		{
			
		}
	}
}