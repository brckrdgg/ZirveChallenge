using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZirveChallenge.Core.Dto
{
    public class MovieSendDto
    {
        [Required(ErrorMessage = "MAil adresi zorunludur")]
        public string email { get; set; }

        [Required(ErrorMessage = "Film id si zorunludur")]
        public int movieId { get; set; }
    }
}
