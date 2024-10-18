using Archieves_Application.Interfaces.Parameters.Common;

namespace Archieves_Application.Parameters.Common
{
    public class ArchievesListRequestParameter : IArchievesListRequestParameter
    {
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 20;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public int? LanguageId { get; set; }
    }
}