namespace Archieves_Application.Interfaces.Parameters.Common
{
    public interface IArchievesListRequestParameter
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}