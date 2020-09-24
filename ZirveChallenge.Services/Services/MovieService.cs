using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Repositories;
using ZirveChallenge.Core.Services;
using ZirveChallenge.Core.UnitOfWorks;
using System.Net.Mail;
using System.Net;
using ZirveChallenge.API.Dto;
using ZirveChallenge.Core.Dto;
using System.Linq;

namespace ZirveChallenge.Services.Services
{
    public class MovieService : Service<Movie>, IMovieService
    {


        public MovieService(IUnitOfWork unitOfWork, IRepository<Movie> repository) : base(unitOfWork, repository)
        {

        }

        public void  GetAllMovieByAPI()
        {
           

             _unitOfWork.Movie.GetAllMovieByAPI();
             _unitOfWork.Commit();
        }

        public IEnumerable<Movie> GetMovieByPageNumber(int pageCount)
        {
           return  _unitOfWork.Movie.GetMovieByPageNumber(pageCount).Result.ToList();
           
        }

        public async Task<MovieWithMovieRatingDto> GetWithMovieRantings(int movieId)
        {
            Movie movie= await _unitOfWork.Movie.GetWithMovieRantingsByIdAsync(movieId);

            if(movie==null)
            {
                throw new System.ArgumentException("Veritabanında bu id de bir film bulunmamaktadır.");
            }
            double average = 0;
            int count = 0;
            int total = 0;

            MovieWithMovieRatingDto movieWithMovieRatingDto = new MovieWithMovieRatingDto();
            movieWithMovieRatingDto.Movie = movie;

            if (movie.MovieRatings.Count!=0)
            {
                foreach (var item in movie.MovieRatings)
                {
                    count++;
                    total = total + item.Puan;
                }
                average = total / count;
                ICollection<MovieRating> movieRating = (ICollection<MovieRating>)await _unitOfWork.MovieRating.GetByMovieId(movieId);

                movieWithMovieRatingDto.Average = average;
                movieWithMovieRatingDto.MovieRatings = movieRating;
            }
            return movieWithMovieRatingDto;

        }


        public async Task MovieSendMail(MovieSendDto movieSendDto)
        {
            int movieId = movieSendDto.movieId;
            string mailAdres = movieSendDto.email;
           
            var movie= await _unitOfWork.Movie.GetByIdAsync(movieId);
            if (movie == null)

            {
                throw new System.ArgumentNullException($"Veritabanında {nameof(movieId)}  idsinde bir film bulunmamaktadır.", nameof(movieId));
            }

            MailMessage msg = new MailMessage();          
            msg.From = new MailAddress("zrvchallnge@gmail.com");
            msg.To.Add(new MailAddress(mailAdres));
            msg.Subject = "Film Önerisi" + " - " + movie.Title;
            msg.Body += "<br> <h1> " + movie.Title + "</h1>";
            msg.Body += "<br> Orjinal Adi : " + movie.Title ;
            msg.Body += "<br>  Populerlik : " + movie.Popularity.ToString();
            msg.Body += "<br> Ortalama Not : " + movie.VoteAverage.ToString();
            msg.Body += "<br> Oy Veren Sayisi : " + movie.VoteCount.ToString();
   
            msg.IsBodyHtml = true;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential AccountInfo = new NetworkCredential("zrvchallnge@gmail.com", "zirve123");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);
            
        }

     
    }

}
