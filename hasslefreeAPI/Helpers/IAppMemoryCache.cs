namespace hasslefreeAPI.Helpers
{
    public interface IAppMemoryCache
    {
        object AddToCache(string KeyName, object obj);
        void RemoveFromCache(string KeyName);
    }
}