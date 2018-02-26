namespace HoteManagement
{
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {
        bool IsAdmin { get; set; }
    }
}