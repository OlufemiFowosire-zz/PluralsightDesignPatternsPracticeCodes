using System;

namespace MediatorDemo.ChatApp
{
    public abstract class TeamMember
    {
        protected ChatRoom chatRoom;
        public string Name { get; }
        public TeamMember(string name)
        {
            Name = name;
        }
        internal void SetChatRoom(ChatRoom chatRoom)
        {
            this.chatRoom = chatRoom;
        }
        public void Send(string message)
        {
            chatRoom.Send(Name, message);
        }
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"from {from}: {message}");
        }
        public virtual void SendTo<T>(string message) where T : TeamMember
        {
            chatRoom.SendTo<T>(Name, message);
        }
    }
}
