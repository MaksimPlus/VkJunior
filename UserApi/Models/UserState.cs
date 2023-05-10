using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Models
{
    [Table("USER_STATE")]
    public class UserState
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("CODE")]
        public CodeState? Code { get; set; } 
        [Column("DESCRIPTION")]
        public string Description { get; set; } = null!;
        
        public List<User> Users { get; set; } = new List<User>();
    }
}
