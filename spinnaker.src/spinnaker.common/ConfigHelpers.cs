namespace rudder.common;

using Microsoft.Extensions.Configuration;
using System;
using System.IO;

/* Reference = https://dusted.codes/dotenv-in-dotnet */


public static class ConfigHelpers
{
    static string _token  = "";
    static string _db_url = "";

    public static void LoadEnviromentVariables() {

        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, ".env");

        loadEnvConfigFile(dotenv);

        var cfg = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();



        _token = cfg.GetValue<string>("JIRA_TOKEN")?.ToString();
        _db_url = cfg.GetValue<string>("DATABASE_URL")?.ToString();
   


        //Config =  (ConfigurationBuilder) cfg;

    }

    public static string GetJIRAToken() {
        //var dbUrl = config.GetValue<string>("DATABASE_URL");
        if (_token == "") LoadEnviromentVariables();
        return _token;
    }

    public static string GetDB_URL() {
        //var dbUrl = config.GetValue<string>("DATABASE_URL");
        if (_db_url == "") LoadEnviromentVariables();
        return _db_url;
    }

    private static void loadEnvConfigFile(string filePath)
    {
        if (!File.Exists(filePath))
            return;

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}


