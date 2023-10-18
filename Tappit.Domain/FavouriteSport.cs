namespace Tappit.Domain
{
    public class FavouriteSport
    {
        public int FavouriteSportId { get; set; }
        public int PersonId { get; set; }
        public int SportId { get; set; }

        //Navigation Properties
        public Person Person { get; set; }
        public Sport Sport { get; set; }
    }

}
