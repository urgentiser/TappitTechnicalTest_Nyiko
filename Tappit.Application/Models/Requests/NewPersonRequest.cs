namespace Tappit.Application.Models.Requests
{
    public class NewPersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAuthorised { get; set; }
    }
}
