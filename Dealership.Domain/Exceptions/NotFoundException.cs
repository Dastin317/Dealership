namespace DealershipManager.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid entryId)
            :base($"Could not find any entries with the following id: {entryId}")
        {
        }
    }
}
