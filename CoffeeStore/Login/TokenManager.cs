using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CoffeeStore.Login
{
    public static class TokenManager
    {
        private static ILoginRepository repository;
        static TokenManager()
        {
            repository = new LoginRepository();
        }

        private const string _alg = "HmacSHA256";
        private const string _salt = "rz8LuOtFBXphj9WQfvFh";

        public static string GenerateToken(string username, string password, string ip, string userAgent, long ticks)
        {
            string hash = string.Join(":", new string[] { username, ip, userAgent, ticks.ToString() });
            string hashLeft = "";
            string hashRight = "";

            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(GetHashedPassword(password));
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));

                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", new string[] { username, ticks.ToString() });
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }

        public static string GetHashedPassword(string password)
        {
            string key = string.Join(":", new string[] { password, _salt });

            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));

                return Convert.ToBase64String(hmac.Hash);
            }
        }

        private const int _expirationMinutes = 5;

        public static bool IsTokenValid(string token)
        {
            bool result = false;

            try
            {
                //Base64 decode the string, obtaining the token: username:timestamp
                string key = Encoding.UTF8.GetString(Convert.FromBase64String(token));

                //split the parts
                string[] parts = key.Split(new char[] { ':' });

                if (parts.Length == 3)
                {
                    //Get the hash message,username, and timestamp
                    string hash = parts[0];
                    string username = parts[1];
                    long ticks = long.Parse(parts[2]);
                    DateTime timeStamp = new DateTime(ticks);

                    //Ensure the timestamp is valid
                    bool expired = Math.Abs((DateTime.UtcNow - timeStamp).TotalMinutes) > _expirationMinutes;
                    if (!expired)
                    {
                        //find password for this user
                        string password = repository.GetPassword(username);
                        string computedToken = GenerateToken(username, password, "2323", "chrome", ticks);
                        result = (token == computedToken);
                    }

                }
                else
                {
                    result = false;

                }

            }
            catch
            {

            }
            return result;

        }

    }
}