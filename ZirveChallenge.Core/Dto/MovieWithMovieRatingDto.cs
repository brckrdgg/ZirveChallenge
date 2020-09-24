using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;

namespace ZirveChallenge.API.Dto
{
    public class MovieWithMovieRatingDto
    {
        /// <summary>
        /// Filmin Ortalama puan hesabının yapılacağı Dto
        /// </summary>
        /// 
       
        public Movie Movie { get; set; }

        public double Average { get; set; }
       
        public ICollection<MovieRating> MovieRatings { get; set; }
    }
}
