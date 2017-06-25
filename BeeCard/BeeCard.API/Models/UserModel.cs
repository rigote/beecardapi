using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;

namespace BeeCard.API.Models
{
    public class BaseUserModel
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarFileName { get; set; }
        public byte[] AvatarContent { get; set; }
        public bool Status { get; set; }
    }

    public class RequestUserModel : BaseUserModel
    {        
        public string Password { get; set; }

        public RequestUserModel()
        {
        }
    }

    public class ResponseUserModel : BaseUserModel
    {
        public Guid Id { get; set; }

        public ResponseUserModel()
        {
        }

        public ResponseUserModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Birthdate = user.Birthdate;
            PhoneNumber = user.PhoneNumber;
            Status = user.Status == EntityStatus.Active ? true : false;
        }
    }
}