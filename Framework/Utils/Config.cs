using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Task3.Framework.Utils
{
    internal class Config
    {
        private static string configsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", @"config.json");
        private static string testDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestCaseSourse", @"test_data.json");

        public static Dictionary<string, string> Settings
        {
            get
            {
                var token = "Config";

                try
                {
                    JObject o = JObject.Parse(File.ReadAllText(configsPath));

                    var options = JsonConvert.DeserializeObject<Dictionary<string, string>>(o.SelectToken("Config").ToString());

                    return options;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Config reader, select token \"{token}\" - {ex.Message}");
                    return null;
                }
            }
        }

        public static Dictionary<string, string> BrowserOptions
        {
            get
            {
                var token = "BrowserOptions";

                try
                {
                    JObject o = JObject.Parse(File.ReadAllText(configsPath));

                    var options = JsonConvert.DeserializeObject<Dictionary<string, string>>(o.SelectToken("BrowserOptions").ToString());

                    return options;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Config reader, select token \"{token}\" - {ex.Message}");
                    return null;
                }
            }
        }

        public static Dictionary<string, string> Log
        {
            get
            {
                var token = "NLog";

                try
                {
                    JObject o = JObject.Parse(File.ReadAllText(configsPath));

                    var options = JsonConvert.DeserializeObject<Dictionary<string, string>>(o.SelectToken("NLog").ToString());

                    return options;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Config reader, select token \"{token}\" - {ex.Message}");
                    return null;
                }
            }
        }

        public static Dictionary<string, string> TestPage
        {
            get
            {
                var token = "Page";

                try
                {
                    JObject o = JObject.Parse(File.ReadAllText(configsPath));

                    var options = JsonConvert.DeserializeObject<Dictionary<string, string>>(o.SelectToken(token).ToString());

                    return options;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Config reader, select token \"{token}\" - {ex.Message}");
                    return null;
                }
            }
        }

        public static IEnumerable<UserData> TestUsers()
        {
            var token = "Users";

            try
            {
                JObject o = JObject.Parse(File.ReadAllText(testDataPath));

                var users = JsonConvert.DeserializeObject<IEnumerable<UserData>>(o.SelectToken(token).ToString());

                return users;
            }
            catch (Exception ex)
            {
                Logger.Error($"Config reader, select token \"{token}\" - {ex.Message}");
                return null;
            }
        }
    }
}