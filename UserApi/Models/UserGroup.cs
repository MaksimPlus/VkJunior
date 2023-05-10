using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Models
{
    [Table("USER_GROUP")]
    public class UserGroup
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("CODE")]
        public CodeGroup? Code { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; } = null!;        
        public List<User> Users { get; set; } = new List<User>();
    }
}
