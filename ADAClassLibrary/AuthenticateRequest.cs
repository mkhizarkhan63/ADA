using System.ComponentModel.DataAnnotations;


namespace ADAClassLibrary
{
    public class AuthenticateRequest
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        public string Username { get; set; } // ACTUAL

        [Required]
        public string Password { get; set; } // ACTUAL
    }
}
