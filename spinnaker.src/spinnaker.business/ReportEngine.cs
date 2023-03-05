using spinnaker.postman;
using spinnaker.common;
using Newtonsoft.Json;

namespace spinnaker.business;
public class ReportEngine
{
    public static Boards GetBoards() {
        JIRAConnector jira = new JIRAConnector();
        Boards bds = new Boards();
        string? json = jira.GetBoardsByProjectKey("RDX");
    
        JIRABoards? jira_boards = JsonConvert.DeserializeObject<JIRABoards>(json);

        foreach (var jb in jira_boards.values) {
            
            Board b = new Board{
                BoardId = jb.id,
                BoardName = jb.name,
                BoardURL = jb.self,
                BoardType = jb.type,
                ProjectId = jb.location.projectId,
                ProjectKey = jb.location.projectKey,
                ProjectName = jb.location.projectName
                
            };

            bds.Add(b);
        }

        return bds;
    }

}