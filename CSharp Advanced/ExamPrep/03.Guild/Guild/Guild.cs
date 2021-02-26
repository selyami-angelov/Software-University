using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.Count)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return this.roster.Remove(this.roster.Find(x => x.Name == name));
        }

        public void PromotePlayer(string name)
        {
            var player = roster.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var player = roster.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            var kicked = this.roster.Where(x => x.Class == clas).ToArray();
            this.roster.RemoveAll(x => kicked.Contains(x));
            return kicked;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in roster)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }

    }
}
