using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZirveChallenge.API.Dto
{
    public class UserDto
    {
        /// <summary>
        /// Kullanıcı EKleme Modeli
        /// </summary>

      //  public int Id { get; set; }

        [Required(ErrorMessage = "İsim zorunludur")]
        public string Name { get; set; }    
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullancı Adı zorunludur")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        public string Password { get; set; }
    }
}
