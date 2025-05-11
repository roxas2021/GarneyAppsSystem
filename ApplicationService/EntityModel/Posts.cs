using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EntityModel
{
    public class Posts
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Content  { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int IsDeleted { get; set; }
        public string Privacy { get; set; }
    }
}
