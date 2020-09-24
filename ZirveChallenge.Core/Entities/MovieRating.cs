using System;
using System.Collections.Generic;
using System.Text;

namespace ZirveChallenge.Core.Entities
{
    public class MovieRating
    {
        /// <summary>
        /// Filme not ve puan ekleme Modeli
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ekleme yapılacak
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// Ekleme yapacak kullanıcı 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Filme yapılan yorum
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Filme 1-10 arası verilen puan
        /// </summary>
        public int Puan { get; set; }



    }
}
