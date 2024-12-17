using System;
using System.Collections.Generic;

namespace LearningPlatform1.Models
{
    public class UserProfileViewModel
    {
        public List<Progress> Progresses { get; set; }
        public List<Achievement> Achievements { get; set; }
        public int Rank { get; set; }
        public int TimeToNextReward { get; set; }
        public List<UserLeaderboardItem> Leaderboard { get; set; }

        public UserProfileViewModel()
        {
            Progresses = new List<Progress>();
            Achievements = new List<Achievement>();
            Leaderboard = new List<UserLeaderboardItem>();
        }
    }

    public class Progres
    {
        public string CourseName { get; set; }
        public int CompletionPercentage { get; set; }
    }

    public class Achievement
    {
        public string BadgeName { get; set; }
        public string CertificateDetails { get; set; }
    }

    public class UserLeaderboardItem
    {
        
        public int UserId { get; set; }
        public int Rank { get; set; }
    }
}
