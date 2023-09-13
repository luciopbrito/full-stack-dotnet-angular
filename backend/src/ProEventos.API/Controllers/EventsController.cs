using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contracts;
using ProEventos.Domain;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet(Name = "GetEvento")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var events = await _eventService.GetAllEventsAsync(true);
            if (events == null) return NotFound("None event found");

            return Ok(events);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error occurred trying to recover events. ERROR: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var ev = await _eventService.GetEventByIdAsync(id);
            if (ev == null) return NotFound("Event by Id does not found");

            return Ok(ev);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error occurred trying to recover events. ERROR: {ex.Message}");
        }
    }

    [HttpGet("{theme}/theme")]
    public async Task<IActionResult> GetByTema(string theme)
    {
        try
        {
            var ev = await _eventService.GetAllEventsByThemeAsync(theme);
            if (ev == null) return NotFound("Events by theme does not found");

            return Ok(ev);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error occurred trying to recover events. ERROR: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Event model)
    {
        try
        {
            var ev = await _eventService.AddEvent(model);
            if (ev == null) return BadRequest("Error occurred trying to add event.");

            return Ok(ev);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error occurred trying to add events. ERROR: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Event model)
    {
        try
        {
            var ev = await _eventService.UpdateEvent(id, model);
            if (ev == null) return BadRequest("Error occurred trying to update event.");

            return Ok(ev);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error occurred trying to update events. ERROR: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return await _eventService.DeleteEvent(id) ?
                Ok("Deleted") :
                BadRequest("Event does not deleted");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error occurred trying to delete events. ERROR: {ex.Message}");
        }
    }

}
