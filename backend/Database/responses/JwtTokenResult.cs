﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.responses
{
    public class JwtTokenResult
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
