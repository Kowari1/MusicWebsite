using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicWEB.Models
{
    public class UserMusic
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int MusicId { get; set; }
        [ForeignKey("MusicId")]
        public Music Music { get; set; }
    }
}
