namespace MarsRoverApp.WebApi.Implementation.Interfaces
{
    public interface IRoverCaching
    {
        bool IsItemExists(object item);
        void SetItem(object key, object value);
        object GetItem(object key);
        void Remove(object key);
    }
}
