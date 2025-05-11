using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.EntityModel
{
    public class user
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string FullName { get; set; }

        public int? Age { get; set; }
        
        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string ContactNo { get; set; }

        public int Role { get; set; }

        public string Status { get; set; } = "Active";

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
        
        public DateTime LastLogin { get; set; }

        public DateTime LastLogout { get; set; }

        public string imageDIR { get; set; }
    }
}
