using ProEventos.Domain;

namespace ProEventos.Persistence.Contracts
{
    public interface IEventPersist
    {
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(string theme, bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers);
    }
}