using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Post
{
    public class PostDetails
    {
        public int PostId { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "Title")]
        public string PostName  { get; set; }
        [Display(Name = "Body")]
        public string PostBody { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public string RaceName { get; set; }
    }
}
