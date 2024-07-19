using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monitoring.Data;
using Monitoring.Models;

namespace Monitoring.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationContext _context;

    public HomeController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var listUserPcViewModels = _context.UserPcs.Include(x => x.Os).Select(x => new ListUserPcViewModel()
        {
            Id = x.Id,
            MachineName = x.Os.MachineName,
            Os = x.Os.Caption
        }).ToList();
        return View(listUserPcViewModels);
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