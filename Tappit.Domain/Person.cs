using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tappit.Domain
{
    public class Person
    { 
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAuthorised { get; set; }

        //Nagigation Property
        public List<FavouriteSport> FavouriteSports { get; set; }
        
        
        public Person UpdateProperties(string firstName, string lastName)
        {
            if (firstName is not null && FirstName?.Equals(firstName) is not true) FirstName = firstName;
            if (lastName is not null && LastName?.Equals(LastName) is not true) LastName = lastName;

            return this;
        }

    }
    
}
