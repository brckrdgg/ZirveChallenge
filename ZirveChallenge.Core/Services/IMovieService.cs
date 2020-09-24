using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.API.Dto;
using ZirveChallenge.Core.Dto;
using ZirveChallenge.Core.Entities;

namespace ZirveChallenge.Core.Services
{
    public interface IMovieService : IService<Movie>
    {

         void GetAllMovieByAPI();

        IEnumerable<Movie> GetMovieByPageNumber(int pageCount);

        Task MovieSendMail(MovieSendDto movieSendDto);

        Task<MovieWithMovieRatingDto> GetWithMovieRantings(int movieId);
    }
}
