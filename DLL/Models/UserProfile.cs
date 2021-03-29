using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UserProfile:BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Icon { get; set; }
        public float Weight { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public BodyType BodyType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
    public enum BodyType
    {
        Ectomorph,
        Mesomorph,
        Endomorph
    }
}
