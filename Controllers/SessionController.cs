using Microsoft.AspNetCore.Mvc;
using StudieøktBackend.Model.DTOs;
using StudieøktBackend.Services.Interfaces;

[ApiController]
[Route("session")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSessionDTO dto)
    {
        var session = await _sessionService.CreateAsync(dto);
        return Ok(session);
    }

    [HttpGet("{date}")]
    public async Task<IActionResult> GetByDate(DateOnly date)
    {
        var sessions = await _sessionService.GetByDateAsync(date);
        return Ok(sessions);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        var success = await _sessionService.DeleteSessionById(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}
