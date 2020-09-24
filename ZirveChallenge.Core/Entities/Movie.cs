using System;
using System.Collections.Generic;
using System.Text;

namespace ZirveChallenge.Core.Entities
{
   public class Movie
    {
        /// <summary>
        /// Db e eklenecek film modeli
        /// </summary>
        public bool Adult { get; set; }

       
        public string BackdropPath { get; set; }
   
        
        public int Id { get; set; }

        /// <summary>
        /// Apıden dönen film idsi
        /// </summary>
        public int MovieId { get; set; }




        public string OriginalLanguage { get; set; }

       
        public string OriginalTitle { get; set; }

       
        public string Overview { get; set; }

      
        public double Popularity { get; set; }

        
        public string PosterPath { get; set; }
   
        public string Title { get; set; }

        
        public bool Video { get; set; }

     
        public double VoteAverage { get; set; }

       
        public long VoteCount { get; set; }

        public ICollection<MovieRating> MovieRatings { get; set; }
    }

}
