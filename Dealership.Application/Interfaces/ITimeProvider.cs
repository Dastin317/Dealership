namespace DealershipManager.Interfaces
{
    public interface ITimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
