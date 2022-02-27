using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Post
{
    public class PostCreate
    {
        public int PostId { get; set; }
        public Guid OwnerId { get; set; }
        public string PostName { get; set; }
        public string PostBody { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
