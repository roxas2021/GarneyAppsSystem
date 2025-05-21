using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage = "Name is required.")]
        public string FullName { get; set; }

        public int? Age { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        public string? ContactNo { get; set; }

        public int Role { get; set; }

        public string Status { get; set; } = "Active";

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
        
        public DateTime LastLogin { get; set; }

        public DateTime LastLogout { get; set; }

        public string imageDIR { get; set; }

        //protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string UserType
        {
            get
            {
                return this.Role == 1 ? "Guest" : "Garbage Collector";
            }
        }

        private DateTime _dob;

        public DateTime DOB { get; set; }
        //public DateTime DOB
        //{
        //    get => _dob;
        //    set
        //    {
        //        if (_dob != value)
        //        {
        //            _dob = value;
        //            OnPropertyChanged();
        //            OnPropertyChanged(nameof(DOBFormatted));
        //        }
        //    }
        //}

        public string DOBFormatted => DOB.ToString("MMMM dd, yyyy");

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
    }
}
