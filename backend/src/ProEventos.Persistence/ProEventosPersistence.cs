using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;

        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Event[]> GetAllEventsAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialMedias);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker);
            }

            query = query.OrderBy(e => e.Id);

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

            query = query.OrderBy(e => e.Id)
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

            query = query.OrderBy(e => e.Id)
                .Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
               .Include(s => s.SocialMedias);

            if (includeEvents)
            {
                query = query.Include(s => s.SpeakerEvents).ThenInclude(se => se.Event);
            }

            query = query.OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
               .Include(s => s.SocialMedias);

            if (includeEvents)
            {
                query = query.Include(s => s.SpeakerEvents).ThenInclude(se => se.Event);
            }

            query = query.OrderBy(s => s.Id).Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int SpeakerId, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
               .Include(s => s.SocialMedias);

            if (includeEvents)
            {
                query = query.Include(s => s.SpeakerEvents).ThenInclude(se => se.Event);
            }

            query = query.OrderBy(s => s.Id).Where(s => s.Id == SpeakerId);

            return await query.FirstOrDefaultAsync();
        }
    }
}