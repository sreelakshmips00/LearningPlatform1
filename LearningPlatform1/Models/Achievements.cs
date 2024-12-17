using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform1.Models
{
    public class Achievements
    {
        public int AchievementId { get; set; }
        public int UserId { get; set; }
        public string BadgeName { get; set; }
        public string CertificateDetails { get; set; }
    }
}