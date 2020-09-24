using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZirveChallenge.API.Dto
{
    public class MovieDto
    {
        /// <summary>
        /// Film içerik modeli
        /// </summary>
        public bool Adult { get; set; }

        public string BackdropPath { get; set; }

        public int Id { get; set; }

        public string OriginalLanguage { get; set; }


        public string OriginalTitle { get; set; }


        public string Overview { get; set; }


        public double Popularity { get; set; }


        public string PosterPath { get; set; }

        public string Title { get; set; }

        public bool Video { get; set; }

        public double VoteAverage { get; set; }
        public long VoteCount { get; set; }

    }
}
