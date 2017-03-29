using System;

namespace BeeCard.API.Models
{
    public class RequestUserModel
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarFileName { get; set; }
        public byte[] AvatarContent { get; set; }
    }
}