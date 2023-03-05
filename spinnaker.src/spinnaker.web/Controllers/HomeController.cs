using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using spinnaker.common;
using spinnaker.web.Models;
using RestSharp;

namespace rudder.web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public  IActionResult IndexAsync()
    {
        Boards boards = getBoards(); //get values from REST API EndPoint instead of calling directly business - this is CLIENT!

        ViewBag.Boards = boards;


        return View();
    }

    //This is for testing purposes for now only
    static Boards getBoards()
    {
        Boards? result = null;

        var client = new RestClient("http://localhost:5134");
        var request = new RestRequest("/api/boards", Method.Get);

        var test = client.Execute<Boards>(request);

        if (test.IsSuccessful)
        {
            result = test.Data;
        }

        return result;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
