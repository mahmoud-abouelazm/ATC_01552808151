using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCore.DTO
{
    public class SignUpDTO
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("password", ErrorMessage = "Please rewrite password correctly")]
        public string confirmPassword { get; set; }
    }
}
