using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public DateTime PackageEndDate { get; set; }
        public string ApiCode { get; set; }

    }
}
