using Archieves_Application.Interfaces.Parameters.Common;

namespace Archieves_Application.Parameters.Common
{
    public class ArchievesRequestParameter : IArchievesRequestParameter
    {
        public int? LanguageId { get; set; }
    }
}