namespace Archieves.Kutuphane.Models.Wrappers
{
    public class Error
    {
        public List<string> Errors { get; set; } = new();
        public Error() { }
        public Error(string error)
        {
            Errors.Add(error);
        }
        public Error(List<string> errors)
        {
            Errors = errors;
        }
    }
}
