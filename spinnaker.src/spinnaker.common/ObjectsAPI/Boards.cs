using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spinnaker.common
{
    public class Boards : List<Board>
    {
        

        public void AddBoards(JIRABoards boards) {

            //JIRABoards? jira_boards = JsonConvert.DeserializeObject<JIRABoards>(json);
            if (boards == null || boards.values == null) return;

            foreach (var jb in boards.values) {
                
                Board b = new Board();
                    b.BoardId = jb.id;
                    b.BoardName = jb.name;
                    b.BoardURL = jb.self;
                    b.BoardType = jb.type;

                    if (jb.location != null) {
                        b.ProjectId = jb.location.projectId;
                        b.ProjectKey = jb.location.projectKey;
                        b.ProjectName = jb.location.projectName;
                    } 
                this.Add(b);

            }
        }

    }

}