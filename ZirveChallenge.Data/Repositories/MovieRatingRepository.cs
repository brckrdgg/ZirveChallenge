using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Helpers;
using ZirveChallenge.Core.Repositories;

namespace ZirveChallenge.Data.Repositories
{
    public class MovieRatingRepository : Repository<MovieRating>, IMovieRatingRepository
    {
 

        public MovieRatingRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<MovieRating> GetByMovieIdAsync(int movieId)
        {
            var query = await GetAllAsync();
            return query.Where(x => x.MovieId == movieId).FirstOrDefault();                     
        }
        public async Task<List<MovieRating>> GetByMovieId(int movieId)
        {
            var user = ActiveUser.Get();
            var query = await GetAllAsync();
            return await query.Where(x => x.MovieId == movieId && x.UserId == user.UserId).ToListAsync();
           
        }
    }
}
