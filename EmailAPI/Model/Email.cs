namespace EmailAPI.Model
{
    public class Email
    {
        [Obsolete]
        public string? FromEmail { get; set; } = Environment.GetEnvironmentVariable("ADM__EMAIL");
        public string ToEmails { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
    }
}
