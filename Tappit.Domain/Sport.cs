using System.Collections.Generic;

namespace Tappit.Domain
{
    public class Sport
    { 
        public int SportId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        //Nagigation Property
        public List<FavouriteSport> FavouriteSports { get; set; }

       
        public Sport UpdateProperties(string name)
        {
            if (name is not null && Name?.Equals(name) is not true) Name = name;

            return this;
        }
    }
}
