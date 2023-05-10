using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Models
{
    [Table("USER")]
    public class User
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("LOGIN")]
        public string Login { get; set; } = null!;
        [Column("PASSWORD")]
        public string Password { get; set; } = null!;
        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }
        [Column("USER_GROUP_ID")]
        public int UserGroupId { get; set; }
        [Column("USER_STATE_ID")]
        public int UserStateId { get; set; }
        public UserGroup UserGroup { get; set; } = null!;
        public UserState UserState { get; set; } = null!;
        public User(int id, string login, string password, DateTime createdDate, int userStateId, int userGroupId)
        {
            Id = id;
            Login = login;
            Password = password;
            CreatedDate = createdDate;
            UserStateId = userStateId;
            UserGroupId = userGroupId;
        }
    }
}
