using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Post Name")]
        public string PostName { get; set; }
        [Required]
        [Display(Name = "Post Body")]
        public string PostBody { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set;}

        [ForeignKey(nameof(Race))]
        public int? RaceId { get; set; }
        public virtual Race Race { get; set; }
    }
}
