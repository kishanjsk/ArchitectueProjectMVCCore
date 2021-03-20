namespace Architecture.Entities.Session
{
    public class MySession
    {
        public string TenantId { get; set; }
        public string TenantName { get; set; }
        public string Role { get; set; }
        public string AuthorizationToken { get; set; }
    }
}
