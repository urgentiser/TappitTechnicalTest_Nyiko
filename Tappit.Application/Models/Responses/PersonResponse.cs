namespace Tappit.Application.Models.Responses
{
    public class PersonResponse
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAuthorised { get; set; }

        public List<FavouriteSportResponse> FavouriteSports { get; set; }
    }
}
