using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Repositories;
using ZirveChallenge.Core.Services;
using ZirveChallenge.Core.UnitOfWorks;

namespace ZirveChallenge.Services.Services
{
    public class MovieRatingService : Service<MovieRating>, IMovieRatingServices
    {

        public MovieRatingService(IUnitOfWork unitOfWork, IRepository<MovieRating> repository) : base(unitOfWork, repository)
        {

        }

        public Task<IEnumerable<MovieRating>> GetByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieRating> GetByMovieIdAsync(int movieId)
        {

            return await _unitOfWork.MovieRating.GetByMovieIdAsync(movieId); ;
        }
    }
}
