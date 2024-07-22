using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monitoring.Data;
using Monitoring.Data.Entity;

namespace Monitoring.Controllers;

[Route("/hardware")]
public class HardwareInfoController : ControllerBase
{
    private readonly ApplicationContext _context;

    public HardwareInfoController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserPc([FromBody] UserPc userPc)
    {
        _context.UserPcs.Add(userPc);
        await _context.SaveChangesAsync();
        return Ok(userPc.Id);
    }


    [HttpGet]
    public async Task<IActionResult> IsUserExist([FromQuery] string userPcId)
    {
        var user = await _context.UserPcs.FirstOrDefaultAsync(x => x.Id == userPcId);
        if (user == null)
        {
            return NotFound();
        }

        return Ok();
    }
}