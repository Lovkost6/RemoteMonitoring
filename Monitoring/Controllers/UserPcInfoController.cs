using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monitoring.Data;

namespace Monitoring.Controllers;

public class UserPcInfoController : Controller
{
    private readonly ApplicationContext _context;

    public UserPcInfoController(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string id)
    {
        var userInfo = await _context.UserPcs.Include(x => x.Os).Include(x => x.Cpu).Include(x => x.Gpu)
            .Include(x => x.Storages).Include(x => x.Rams).Include(x => x.MotherBoard).
            FirstOrDefaultAsync(x => x.Id == id);
        if (userInfo is null) return NotFound();
        
        return View(userInfo);
    }
}