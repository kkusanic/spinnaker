namespace spinnaker.common;

using Microsoft.Extensions.Configuration;
using System;
using System.IO;

/* Reference = https://dusted.codes/dotenv-in-dotnet */


public static class ConfigHelpers
{
    static string _jira_instance = "";
    static string _jira_token  = "";
    static string _db_url = "";

    public static void LoadEnviromentVariables() {

        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, ".env");

        loadEnvConfigFile(dotenv);

        var cfg = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();

        _jira_instance = cfg.GetValue("JIRA_INSTANCE", "")?.ToString();
        _jira_token = cfg.GetValue<string>("JIRA_TOKEN")?.ToString();
        _db_url = cfg.GetValue<string>("DATABASE_URL")?.ToString();
    }

    public static string GetJIRAInstance() {
        if (_jira_instance == "") LoadEnviromentVariables();
        _jira_instance = (!_jira_instance.EndsWith("/")) ? _jira_instance : (_jira_instance + "/"); //instance URL must be terminated with "/"
        return _jira_instance;
    }

    public static string GetJIRAToken() {
        if (_jira_token == "") LoadEnviromentVariables();
        return _jira_token;
    }

    public static string GetDB_URL() {
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


