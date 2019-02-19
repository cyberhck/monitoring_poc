using System.ComponentModel.DataAnnotations;

namespace Rooft.Requests.Users
{
    public class CreateUser
    {
        [MinLength(6)]
        public string Username { set; get; }
        
        [EmailAddress]
        public string Email { set; get; }
        
        [MinLength(8)]
        public string Password { set; get; }
    }
}