using System.Collections.Generic;

namespace SimpleApp.Project1.Models
{
    public class Vote
    {
        private static Dictionary<Color, int> votes = new Dictionary<Color, int>();

        public static void RecordVote(Color color)
        {
            votes[color] = votes.ContainsKey(color) ? votes[color] + 1 : 1;
        }

        public static void ChangeVote(Color newColor, Color oldColor)
        {
            if(votes.ContainsKey(oldColor))
            {
                votes[oldColor]--;
            }
            RecordVote(newColor);
        }

        public static int GetVotes(Color color)
        {
            return votes.ContainsKey(color) ? votes[color] : 0;
        }
    }
}