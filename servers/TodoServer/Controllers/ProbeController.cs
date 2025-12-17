using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Services;

namespace TodoServer.Controllers;

[Route("")]
[ApiController]
public class ProbeController : ControllerBase
{
    private readonly AppState _appState;
    public ProbeController(AppState appState) => _appState = appState;

    [HttpGet("/startup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public IActionResult StartUp() => _appState.StartUp ? Ok() : StatusCode(503);

    [HttpGet("/ready")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public IActionResult Readiness() => _appState.Ready ? Ok() : StatusCode(503);

    [HttpGet("healthz")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Liveness() => Ok();
}
