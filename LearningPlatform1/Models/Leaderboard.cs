using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform1.Models
{
    public class Leaderboard
    {
        public int LeaderboardId { get; set; }
        public int UserId { get; set; }
        public int Rank { get; set; }
    }
}