using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;

namespace ZirveChallenge.Core.Repositories
{
     public interface IMovieRatingRepository : IRepository<MovieRating>
    {

        Task<MovieRating> GetByMovieIdAsync(int movieId);

        Task<List<MovieRating>> GetByMovieId(int movieId);

    }
}
