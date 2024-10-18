namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface ILogService
    {
        // Custom methods for ILogService
        Task<bool> Log(string type, string message);
    }
}