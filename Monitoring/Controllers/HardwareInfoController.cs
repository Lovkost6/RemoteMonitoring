using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> CreateUserPc([FromBody]UserPc userPc)
    {
        _context.UserPcs.Add(userPc);
        await _context.SaveChangesAsync();
        return Ok(userPc.Id);
    }
}