namespace Tappit.Application.Models.Requests
{
    public class UpdatePersonRequest
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAuthorised { get; set; }

        /// <summary>
        /// Checked or Uncheck Sports - Used by checkbox
        /// </summary>
        public List<FavouriteSportViewModel> FavouriteSports { get; set; }
    }
}
