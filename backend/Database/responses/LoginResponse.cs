using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.responses
{
    public class LoginResponseData
    {
        public JwtTokenResult JwtToken { get; set; }
        public UserResponseData User { get; set; }
    }
}
