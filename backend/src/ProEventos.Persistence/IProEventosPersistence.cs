using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        // GENERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // EVENTS
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(string theme, bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers);

        // SPEAKERS
        Task<Speaker[]> GetAllSpeakersByNameAsync(string Name, bool includeEvents);
        Task<Speaker[]> GetAllSpeakersAsync(string theme, bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int SpeakerId, bool includeEvents);

    }
}