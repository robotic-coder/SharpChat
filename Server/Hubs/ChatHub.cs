using Microsoft.AspNetCore.SignalR;
using ChatApplication.Shared;

namespace ChatApplication.Server.Hubs
{
    public class ChatHub : Hub
    {
        private static List<Message> messageHistory = new List<Message>();
        private static Dictionary<string, User> users = new Dictionary<string, User>();
        private static Dictionary<string, User> chatConnections = new Dictionary<string, User>();

        public string Register(string name, string surname, string username)
        {
            var user = new User(name, surname, username);
            var loginKey = Guid.NewGuid().ToString();
            users.Add(loginKey, user);
            return loginKey;
        }

        public bool CheckKey(string loginKey)
        {
            return users.ContainsKey(loginKey);
        }

        public async Task<Tuple<string, List<Message>>?> JoinChat(string loginKey)
        {   
            if (users.ContainsKey(loginKey)) {
                var user = users[loginKey];
                chatConnections.Add(Context.ConnectionId, user);
                await SendHelper(new SystemMessage($"{user.Name} {user.Surname} ({user.Username}) has entered the chat"));
                return new Tuple<string, List<Message>>(user.Id, messageHistory);
            }
            else
            {
                await Clients.Caller.SendAsync("InvalidKey");
                return null;
            }
        }

        public async Task SendMessage(string message)
        {
            var user = GetCurrentUser();
            if (user != null)
            {
                await SendHelper(new UserMessage(user, message));
            }
            else
            {
                await Clients.Caller.SendAsync("InvalidKey");
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = GetCurrentUser();
            if (user != null)
            {
                await SendHelper(new SystemMessage($"{user.Name} {user.Surname} ({user.Username}) has left the chat"));
            }
        }

        private async Task SendHelper(Message msg)
        {
            messageHistory.Add(msg);
            await Clients.All.SendAsync("ReceiveMessage", msg);
        }

        private User? GetCurrentUser()
        {
            if (chatConnections.ContainsKey(Context.ConnectionId))
            {
                return chatConnections[Context.ConnectionId];
            }
            else
            {
                return null;
            }
        }
    }
}