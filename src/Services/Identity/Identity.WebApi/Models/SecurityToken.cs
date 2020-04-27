namespace Identity.WebApi.Models
{
    public class SecurityToken
    {
        public string AuthToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
