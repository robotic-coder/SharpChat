namespace backend.Hubs
{
    public abstract class Message
    {
		public bool IsSystem { get; }
		public string Sender { get; }
		public string Text { get; }
		public Tuple<int, int, int> Color { get; }
		public DateTime Time { get; } = DateTime.Now;
		
        protected Message(bool isSystem, string sender, string text, Tuple<int, int, int> color)
		{
			IsSystem = isSystem;
			Sender = sender;
			Text = text;
			Color = color;
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