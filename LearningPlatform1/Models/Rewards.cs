using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform1.Models
{
    public class Rewards
    {
        public int RewardId { get; set; }
        public int UserId { get; set; }
        public int TimeToNextReward { get; set; }
    }
}