using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class LogedUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
