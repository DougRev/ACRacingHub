using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Post
{
    public class PostListItem
    {
        [Display(Name="ID")]
        public int PostId { get; set; }
        [Display(Name = "Title")]
        public string PostName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public string RaceName { get; set; }
    }
}
