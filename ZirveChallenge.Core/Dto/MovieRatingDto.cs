using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZirveChallenge.API.Dto
{
    public class MovieRatingDto
    {
      /// <summary>
      /// Filme Puan ve Note Ekleme modeli
      /// </summary>

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Note { get; set; }

        [Range(1, 11, ErrorMessage = "{0} alanı 1 ile 10 arası değer almalıdır")] // min max değer
        public int Puan { get; set; }

        public int UserId { get; set; }
    }
}
