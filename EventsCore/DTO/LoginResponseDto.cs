using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCore.DTO
{
    public class LoginResponseDto
    {
        public UserDto user { get; set; }
        public string token { get; set; }
    }
}
