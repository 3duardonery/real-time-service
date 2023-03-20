namespace RealTimeEventService.Api.Models
{
    public sealed class Event
    {
        public Event()
        {
            Id = Guid.NewGuid().ToString();
            DispatchedAt = DateTime.Now;
        }

        public string Id { get; private set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? Link { get; set; }
        public DateTime DispatchedAt { get; private set; }
    }
}
