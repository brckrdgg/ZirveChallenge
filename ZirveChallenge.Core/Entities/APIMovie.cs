using System;
using System.Collections.Generic;
using System.Text;

namespace ZirveChallenge.Core.Entities
{
    public class APIMovie
    {
        /// <summary>
        /// https://www.themoviedb.org/ Apıden dönen film  modeli
        /// </summary>
        public partial class Temperatures
        {
           
            public long Page { get; set; }

            
            public long TotalResults { get; set; }

           
            public long TotalPages { get; set; }

          
            public Result[] Results { get; set; }
        }

        public partial class Result
        {
            
            public double Popularity { get; set; }

            
            public long VoteCount { get; set; }

            public bool Video { get; set; }

            
            public string PosterPath { get; set; }

            
            public long Id { get; set; }

            
            public bool Adult { get; set; }

            
            public string BackdropPath { get; set; }

            
            public OriginalLanguage OriginalLanguage { get; set; }

            
            public string OriginalTitle { get; set; }

            
            public long[] GenreIds { get; set; }

           
            public string Title { get; set; }

           
            public double VoteAverage { get; set; }

           
            public string Overview { get; set; }

            public DateTimeOffset ReleaseDate { get; set; }
        }

        public enum OriginalLanguage { En, Es, Ko };
    }
}

