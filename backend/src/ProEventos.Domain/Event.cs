namespace ProEventos.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime DateEvent { get; set; }
        public string Theme { get; set; }
        public int QtdPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch>? Batches { get; set; }
        public IEnumerable<SocialMedia>? SocialMedias { get; set; }
        public IEnumerable<SpeakerEvent>? SpeakerEvents { get; set; }
    }
}