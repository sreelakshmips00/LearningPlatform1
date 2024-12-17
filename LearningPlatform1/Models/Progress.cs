using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform1.Models
{
    public class Progress
    {
        public int ProgressId { get; set; }
        public int UserId { get; set; }
        public string CourseName { get; set; }
        public int CompletionPercentage { get; set; }
    }
}