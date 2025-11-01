namespace SportZone_MVC.DTOs
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public bool Flag { get; internal set; }
    }
}
