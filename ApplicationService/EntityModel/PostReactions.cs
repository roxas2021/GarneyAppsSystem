using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EntityModel
{
    public class PostReactions
    {
        public int ReactionID { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
