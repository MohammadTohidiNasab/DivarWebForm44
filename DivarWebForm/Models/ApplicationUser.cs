using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DivarWebForm.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
<<<<<<< HEAD
    }
}

=======
        public string PhoneNumber { get; set; }
    }
}
>>>>>>> c7edd6e282c450f569a0aa7bbb2bbeb6ca3b2f50
