using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Helpers;
using Darkec.Models;
using Microsoft.AspNetCore.Identity;

namespace Darkec.Services.Users
{
    public class UserRepository : IObjectRepository<int, User>
    {
        private string JsonFileName = @".\wwwroot\Data\JsonUsers.json";

        private Dictionary<int, User> users;

        public UserRepository()
        {
            users = JsonFileReader<int, User>.ReadJson(JsonFileName);
            if (users == null)
            {
                users = new Dictionary<int, User>();
            }
        }

        public Dictionary<int, User> GetAllObjects()
        {
            return users;
        }

        public void AddObject(User user)
        {
            AutoIncrementId(user);
            user.Password = PasswordHash(user.Email, user.Password);
            users.Add(user.Id, user);
            JsonFileWriter<int, User>.WriteToJson(users, JsonFileName);
        }

        public User GetObject(int id)
        {
            return users[id];
        }

        public void UpdateObject(User user)
        {
            if (user != null)
            {
                user.Password = PasswordHash(user.Email, user.Password);
                users[user.Id] = user;
                JsonFileWriter<int, User>.WriteToJson(users, JsonFileName);
            }
        }

        public void DeleteObject(User user)
        {
            if (user != null)
            {
                users.Remove(user.Id);
                JsonFileWriter<int, User>.WriteToJson(users, JsonFileName);
            }
        }

        public Dictionary<int, User> FilterObjects(string email)
        {

            Dictionary<int, User> filteredUsers = new Dictionary<int, User>();

            foreach (User user in users.Values)
            {
                if (user.Email.StartsWith(email))
                {
                    filteredUsers.Add(user.Id, user);
                }
            }
            return filteredUsers;
        }
        public User AutoIncrementId(User user)
        {
            List<int> userId = new List<int>();
            foreach (var User in users.Values)
            {
                userId.Add(User.Id);
            }
            if (userId.Count != 0)
            {
                int increment = userId.Max() + 1;
                user.Id = increment;
            }
            else
            {
                user.Id = 1;
            }
            return user;
        }

        public string PasswordHash(string userName, string password)
        {
            PasswordHasher<string> pw = new PasswordHasher<string>();
            string passwordHashed = pw.HashPassword(userName, password);
            return passwordHashed;
        }
        public User CheckedUser(string email, string password)
        {
            User user = null;
            foreach (var User in users.Values)
            {
                if (User.Email == email)
                {
                    string jsonPassword = User.Password;
                    PasswordHasher<string> pw = new PasswordHasher<string>();
                    var verificationResult = pw.VerifyHashedPassword(email, jsonPassword, password);
                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        user = User;
                    }
                    
                    return user;
                }
            }
            return user;
        }

        //Two methods that don't have implementation but are here since this class inherits the IObjectRepository interface.
        //This could be solved by having the class not implement the interface but that comes with its own complications.
        public void BookObject(User user1, User user2)
        {

        }
        public void CancelObject(User user1, User user2)
        {

        }
    }
}