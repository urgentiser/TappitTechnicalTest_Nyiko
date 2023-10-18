namespace Tappit.Application.Models.Requests
{
    public class UpdateSportRequest
    {
        public int SportId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
