namespace Tappit.Application.Models.Responses
{
    public class FavouriteSportResponse
    {
        public int FavouriteSportId { get; set; }
        public int PersonId { get; set; }
        public int SportId { get; set; }

        public PersonResponse Person { get; set; }
        public SportResponse Sport { get; set; }
    }
}
