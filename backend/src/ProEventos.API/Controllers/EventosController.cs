using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Persistence.Context;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    public ProEventosContext _context { get; }
    public EventosController(ProEventosContext context)
    {
        this._context = context;
    }

    [HttpGet(Name = "GetEvento")]
    public IEnumerable<Event> Get()
    {
        return _context.Events;
    }

    [HttpGet("{id}")]
    public Event GetById(int id)
    {
        return _context.Events.FirstOrDefault(
            e => e.Id == id
        );
    }
}
