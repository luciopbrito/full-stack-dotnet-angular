using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Persistence
{
    public class EventPersist : IEventPersist
    {
        private readonly ProEventosContext _context;

        public EventPersist(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialMedias);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialMedias);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
               .Include(e => e.Batches)
               .Include(e => e.SocialMedias);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }

    }
}