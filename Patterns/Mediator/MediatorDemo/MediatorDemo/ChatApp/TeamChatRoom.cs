using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatorDemo.ChatApp
{
    public class TeamChatRoom : ChatRoom
    {
        private List<TeamMember> teamMembers = new List<TeamMember>();
        public override void Register(TeamMember member)
        {
            member.SetChatRoom(this);
            teamMembers.Add(member);
        }

        public override void Send(string from, string message)
        {
            teamMembers.ForEach(m => m.Receive(from, message));
        }
        public void RegisterTeamMembers(params TeamMember[] teamMembers)
        {
            foreach (var teamMember in teamMembers)
            {
                Register(teamMember);
            }
        }

        public override void SendTo<T>(string from, string message)
        {
            teamMembers.OfType<T>().ToList<T>().ForEach(m => m.Receive(from, message));
        }
    }
}
