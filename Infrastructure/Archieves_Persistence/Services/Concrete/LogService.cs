using Archieves_Application.Interfaces.Services.Abstract;

namespace Archieves_Persistence.Services.Concrete
{
    public class LogService : ILogService
    {
        #region Properties

        #endregion
        #region Constructor

        #endregion
        #region Methods
        public Task<bool> Log(string type, string message)
        {
            throw new NotImplementedException();
        }

        private Task<bool> LogToFile(string type, string message)
        {
            throw new NotImplementedException();
        }

        private Task<bool> LogToDatabase(string type, string message)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}