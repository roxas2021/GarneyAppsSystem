using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EntityModel
{
    public class PostImages
    {
        public int ImageID { get; set; }
        public int PostID { get; set; }
        public string ImagePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
