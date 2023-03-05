using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using spinnaker.common;

namespace spinnaker.web.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class boardsController : ControllerBase
    {
        
        [HttpGet]
         public ActionResult<IEnumerable<Boards>> Get()
        {
            Boards boards = spinnaker.business.ReportEngine.GetBoards();

            return new JsonResult(boards);
        }
        

        /*
        [HttpGet]
        public HttpResponseMessage Get(string projectKey) {
            Boards boards = spinnaker.business.ReportEngine.GetBoards();
            
            // Return the data as a JSON array in the HTTP response
            string json = JsonConvert.SerializeObject(boards);

            
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
        */
    }
}