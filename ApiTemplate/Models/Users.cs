using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTemplate.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirdthDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool? Sex { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Active { get; set; }

        //[NotMapped]
        public string AccessToken { get; set; }
        //[NotMapped]
        public DateTime ExpireAccessToken { get; set; }
    }
}
