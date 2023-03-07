using spinnaker.postman;
using spinnaker.common;
using Newtonsoft.Json;

namespace spinnaker.business;
public class ReportEngine
{
    public static Boards GetBoards() {
        JIRAConnector jira = new JIRAConnector();

        JIRABoards? fetchedBoards;
        Boards allBoards = new Boards();
                
        string json = "";
        int pageStart = 0;
        
        json = jira.GetAllBoards(pageStart);
        fetchedBoards = JsonConvert.DeserializeObject<JIRABoards>(json);

        if (fetchedBoards == null) return allBoards;
        
        allBoards.AddBoards(fetchedBoards);
        
        int totalRecords = fetchedBoards.total;

            //Let's put child node with issues in List object - this will be used to append new issues found
            if (totalRecords > ConfigHelpers.JIRA_MAX_RESULTS)
            {
                //2. divide in loop and go through it
                int pageCount = Convert.ToInt32(Math.Floor((decimal)totalRecords / ConfigHelpers.JIRA_MAX_RESULTS));

                for (int i = 1; i <= pageCount; i++) //careful, starting with i=100 (2nd page, as we already have 1st fethced)
                {
                    //now I need to append to existing issues collection from the first call
                    pageStart = i * ConfigHelpers.JIRA_MAX_RESULTS;

                    json = jira.GetAllBoards(pageStart);
                    fetchedBoards = JsonConvert.DeserializeObject<JIRABoards>(json);                    
                    if (fetchedBoards == null) break;

                    allBoards.AddBoards(fetchedBoards);
                }
            }        


        return allBoards;
    }

        /*
        public static List<JiraIssue> getJiraIssueList(string jql)
        {
            int pageSize = 100;
            int pageStart = 0;
            List<JiraIssue> storedIssues = new List<JiraIssue>();
            JiraIssueList newFetchedJiraIssues = getJiraIssueListFromPage(jql, pageStart, pageSize);
            int totalRecords = newFetchedJiraIssues.total;

            //1st let's fetch this to separate collection that will be used as a baseline and to append on top of it
            addToPrivateColletion(ref storedIssues, ref newFetchedJiraIssues);


            //Let's put child node with issues in List object - this will be used to append new issues found
            if (totalRecords > pageSize)
            {
                //2. divide in loop and go through it
                int pageCount = Convert.ToInt32(Math.Floor((decimal)totalRecords / pageSize));

                for (int i = 1; i <= pageCount; i++) //careful, starting with i=100 (2nd page, as we already have 1st fethced)
                {
                    //now I need to append to existing issues collection from the first call
                    pageStart = i * pageSize;
                    newFetchedJiraIssues = getJiraIssueListFromPage(jql, pageStart, pageSize);
                    addToPrivateColletion(ref storedIssues, ref newFetchedJiraIssues);
                }
            }

            return storedIssues;
        }
        */    

}