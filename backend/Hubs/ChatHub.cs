using Microsoft.AspNetCore.SignalR;

namespace backend.Hubs
{
    public class ChatHub : Hub
    {
        private List<Message> messageHistory = new List<Message>();
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public async Task Register(string name, string surname, string username)
        {
            Console.WriteLine($"Registering user {username}");
            var user = new User(name, surname, username);
            users.Add(user.Id, user);
            await Clients.Caller.SendAsync("ReadyToJoin", user.Id, messageHistory);
        }

        public async Task JoinChat(string user)
        {
            await SendHelper(new SystemMessage($"{user} joined the chat"));
        }

        public async Task SendMessage(string userID, string message)
        {
            if (users.ContainsKey(userID))
            {
                await SendHelper(new UserMessage(users[userID], message));
            }
            else
            {
                await Clients.Caller.SendAsync("InvalidLogin");
            }
        }

        public async Task LeaveChat(string user)
        {
            await SendHelper(new SystemMessage($"{user} left the chat"));
        }

        private async Task SendHelper(Message msg)
        {
            messageHistory.Add(msg);
            await Clients.All.SendAsync("ReceiveMessage", msg);
        }
    }
}