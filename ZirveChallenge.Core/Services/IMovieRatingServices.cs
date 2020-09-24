using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;

namespace ZirveChallenge.Core.Services
{
    public interface IMovieRatingServices : IService<MovieRating>
    {
        Task<MovieRating> GetByMovieIdAsync(int movieId);

        Task<IEnumerable<MovieRating>> GetByMovieId(int movieId);
    }
}
