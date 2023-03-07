namespace spinnaker.postman;

using System.Net;
using System.Net.Http.Headers;
using spinnaker.common;

public class JIRAConnector
{

    public string GetAllBoards(int startAt = 0, int maxResults = 50) {

        string apiCall = string.Format("{0}?startAt={1}&maxResults={2}", 
                                    JIRA_RESTAPI.API_BOARDS, startAt, maxResults);

        var res = getJiraJSONResponse(apiCall);

        return res;
    }

    private string getJiraJSONResponse(string api_request) {

        var instance = common.ConfigHelpers.GetJIRAInstance();
        var token = common.ConfigHelpers.GetJIRAToken();
        string result;

        // Make the API call
        string apiEndpoint = string.Format("{0}{1}", instance, api_request);

        using (WebClient client = new WebClient()){

            client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", token);
            result = client.DownloadString(apiEndpoint);

        }

        return result;
    }

/*
    private async Task<string> getJiraJSONResponse(string api_request) {
        var httpClient = new HttpClient();
        var instance = common.ConfigHelpers.GetJIRAInstance();
        var token = common.ConfigHelpers.GetJIRAToken();

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

        // Make the API call
        string apiEndpoint = string.Format("{0}{1}", instance, api_request);
        
        var response = await httpClient.GetAsync(apiEndpoint);
        var responseContent = await response.Content.ReadAsStringAsync();        

        return responseContent;
    }
*/
}
