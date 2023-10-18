namespace Tappit.Application.Models.Requests
{
    public class FavouriteSportViewModel
    {
        public int PersonId { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
        public bool IsFavourite { get; set; }
    }
}
