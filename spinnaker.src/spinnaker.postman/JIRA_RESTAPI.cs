using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spinnaker.postman
{
    //
    // This static class is dictionary of all rest calls
    // For complete reference guide, visit: https://developer.atlassian.com/cloud/jira/software/rest/intro/
    //
    public class JIRA_RESTAPI
    {
        public static string API_BOARDS { get { return "rest/agile/1.0/board/"; }}
        public static string API_SPRINT { get { return "rest/agile/1.0/sprint/"; }}
        public static string API_BOARD_SPRINTS { get { return "rest/agile/1.0/board/{0}/sprint"; }}
        public static string API_SPRINT_TICKETS { get { return "rest/agile/1.0/sprint/{0}/issue"; } }

    }
}