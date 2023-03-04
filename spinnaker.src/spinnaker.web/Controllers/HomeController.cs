using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using rudder.web.Models;
using rudder.common;

namespace rudder.web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var dbUrl = ConfigHelpers.GetDB_URL();
        var token = ConfigHelpers.GetJIRAToken();

        Debug.Print("dbUrl: " + dbUrl);
        Debug.Print("token: " + token);

        ViewBag.DBUrl = dbUrl;
        ViewBag.Token = token;

        return View();
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
