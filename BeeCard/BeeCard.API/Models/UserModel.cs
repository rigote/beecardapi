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
        public string AvatarBase64 { get; set; }
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
            AvatarBase64 = user.Photo;
        }
    }

    public class BaseUserGroupModel
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }

    public class RequestUserGroupModel : BaseUserGroupModel
    {
    }

    public class ResponseUserGroupModel : BaseUserGroupModel
    {
        public Guid UserGroupId { get; set; }
        public Guid UserId { get; set; }

        public ResponseUserGroupModel()
        {

        }

        public ResponseUserGroupModel(UserGroup userGroup)
        {
            UserGroupId = userGroup.ID;
            UserId = userGroup.UserID;
            Name = userGroup.Name;
            Status = userGroup.Status == EntityStatus.Active;
        }
    }
}