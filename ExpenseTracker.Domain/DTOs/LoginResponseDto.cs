using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.DTOs
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
    }
}
