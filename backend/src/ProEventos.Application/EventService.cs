using ProEventos.Application.Contracts;
using ProEventos.Domain;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Application
{
    public class EventService : IEventService
    {
        private readonly IEventPersist _eventPersist;
        private readonly IGeneralPersist _generalPersist;

        public EventService(IEventPersist eventPersist, IGeneralPersist generalPersist)
        {
            _eventPersist = eventPersist;
            _generalPersist = generalPersist;
        }

        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                _generalPersist.Add<Event>(model);

                if (await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var even = await _eventPersist.GetEventByIdAsync(eventId);
                if (even == null) throw new Exception("Event does not found.");

                _generalPersist.Delete<Event>(even);

                return await _generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var even = await _eventPersist.GetEventByIdAsync(eventId);
                if (even == null) return null;

                model.Id = even.Id;

                _generalPersist.Update(model);

                if (await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                return await _eventPersist.GetAllEventsAsync(includeSpeakers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeakers);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventPersist.GetEventByIdAsync(eventId, includeSpeakers);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}