using LearningPlatform1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningPlatform1.Controllers
{
    public class ProfileController : Controller
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LearningPlatformDB"].ConnectionString;

        // Login Page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    int userId = (int)reader["UserId"];
                    Session["UserId"] = userId;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Error = "Invalid username or password.";
                    return View();
                }
            }
        }

        // Dashboard
        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login");

            int userId = (int)Session["UserId"];
            var model = new UserProfileViewModel
            {
                Progresses = new List<Progress>(),
                Achievements = new List<Achievement>(),
                Leaderboard = new List<UserLeaderboardItem>()
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch Progress
                string progressQuery = "SELECT CourseName, CompletionPercentage FROM Progress WHERE UserId = @UserId";
                SqlCommand progressCommand = new SqlCommand(progressQuery, connection);
                progressCommand.Parameters.AddWithValue("@UserId", userId);
                SqlDataReader progressReader = progressCommand.ExecuteReader();

                while (progressReader.Read())
                {
                    model.Progresses.Add(new Progress
                    {
                        CourseName = progressReader["CourseName"].ToString(),
                        CompletionPercentage = Convert.ToInt32(progressReader["CompletionPercentage"])
                    });
                }

                progressReader.Close();

                // Fetch Achievements
                string achievementQuery = "SELECT BadgeName, CertificateDetails FROM Achievements WHERE UserId = @UserId";
                SqlCommand achievementCommand = new SqlCommand(achievementQuery, connection);
                achievementCommand.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader achievementReader = achievementCommand.ExecuteReader();
                while (achievementReader.Read())
                {
                    model.Achievements.Add(new Achievement
                    {
                        BadgeName = achievementReader["BadgeName"].ToString(),
                        CertificateDetails = achievementReader["CertificateDetails"].ToString()
                    });
                }

                achievementReader.Close();

                // Fetch Leaderboard
                string leaderboardQuery = "SELECT UserId, Rank FROM Leaderboard ORDER BY Rank" ;
                SqlCommand leaderboardCommand = new SqlCommand(leaderboardQuery, connection);
                SqlDataReader leaderboardReader = leaderboardCommand.ExecuteReader();
                while (leaderboardReader.Read())
                {
                    model.Leaderboard.Add(new UserLeaderboardItem
                    {
                       
                        UserId = Convert.ToInt32(leaderboardReader["UserId"]),
                        Rank = Convert.ToInt32(leaderboardReader["Rank"])
                    });
                }

                leaderboardReader.Close();

                // Fetch Rank and Rewards
                string userRankQuery = "SELECT Rank FROM Leaderboard WHERE UserId = @UserId";
                SqlCommand userRankCommand = new SqlCommand(userRankQuery, connection);
                userRankCommand.Parameters.AddWithValue("@UserId", userId);
                object rankResult = userRankCommand.ExecuteScalar();
                model.Rank = rankResult != null ? Convert.ToInt32(rankResult) : 0;

                string rewardsQuery = "SELECT TimeToNextReward FROM Rewards WHERE UserId = @UserId";
                SqlCommand rewardsCommand = new SqlCommand(rewardsQuery, connection);
                rewardsCommand.Parameters.AddWithValue("@UserId", userId);
                object rewardsResult = rewardsCommand.ExecuteScalar();
                model.TimeToNextReward = rewardsResult != null ? Convert.ToInt32(rewardsResult) : 0;
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            // Clear the user session
            Session.Clear();       // Clears all session data
            Session.Abandon();     // Abandons the session

            // Redirect to the Login page
            return RedirectToAction("Login", "Profile");
        }



    }
}
