using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Post
{
    public class PostEdit
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostBody { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
