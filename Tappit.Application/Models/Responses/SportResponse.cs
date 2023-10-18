namespace Tappit.Application.Models.Responses
{
    public class SportResponse
    {
        public int SportId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public List<FavouriteSportResponse> FavouriteSports { get; set; }
    }
}
