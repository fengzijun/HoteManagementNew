namespace HoteManagement.Service.Events
{
    public interface IConsumer<T>
    {
        void HandleEvent(T eventMessage);
    }
}