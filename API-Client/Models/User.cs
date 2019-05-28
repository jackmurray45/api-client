using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace API_Client
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int ApiUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
