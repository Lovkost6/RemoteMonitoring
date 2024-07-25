using HardWareMonitorService.Entity.Monitoring.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Monitoring.Controllers;

public class MonitoringController : Controller
{
    public MonitoringController()
    {
    }

    public IActionResult Index(string id)
    {
        var userPcId = new UserPcIdViewModel()
        {
            UserPcId = id
        };
        return View(userPcId);
    }
}