using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZirveChallenge.Core.Dto
{
    public class LoginDto
    {
        [Required (ErrorMessage ="Kullancı Adı zorunludur")]
        public string Username { get; set; }

        [Required (ErrorMessage = "Şifre zorunludur")]
        public string Password { get; set; }
     
    }
}
