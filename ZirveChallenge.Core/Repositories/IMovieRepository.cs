using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;

namespace ZirveChallenge.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task GetAllMovieByAPI();

        Task<IEnumerable<Movie>> GetMovieByPageNumber(int pageCount);
        Task<Movie> MovieGetById(int movieId);

        Task<Movie> GetWithMovieRantingsByIdAsync(int movieId);


    }
}
