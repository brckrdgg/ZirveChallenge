using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Repositories;
using ZirveChallenge.Core.Services;
using static ZirveChallenge.Core.Entities.APIMovie;

namespace ZirveChallenge.Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {

       const int dataCount = 20;
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public MovieRepository(AppDbContext context) : base(context)
        {
            

        }

        public async Task  GetAllMovieByAPI()
        {

            var query = await GetAllAsync();


            for (int count = 1; count <= 25; count++)
            {
                var apiUrl = "https://api.themoviedb.org/3/movie/popular?api_key=4d4eee4090b9c5f9c62fc64c6c8b9fd3&language=en-US&page=" + count;
                Uri url = new Uri(apiUrl);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                string json = client.DownloadString(url);

                Temperatures bsObj = JsonConvert.DeserializeObject<Temperatures>(json);
               
                var eklenecekler = bsObj.Results.Where(x => !query.Select(y => y.MovieId).ToList().Contains((int)x.Id)).Select(z=> new Movie() {

                    Adult = z.Adult,
                    MovieId = (int)z.Id,
                    BackdropPath = z.BackdropPath,
                    OriginalLanguage = z.ToString(),
                    OriginalTitle = z.OriginalTitle,
                    Overview =z.Overview,
                    Popularity = z.Popularity,
                    PosterPath = z.PosterPath,
                    Title = z.Title,
                    Video = z.Video,
                    VoteAverage = z.VoteAverage,
                    VoteCount = z.VoteCount,
                }).ToList();

                 AddRangeAsync(eklenecekler);

            }
        }


        public async Task<IEnumerable<Movie>> GetMovieByPageNumber(int pageCount)
        {

            int startcount = dataCount * pageCount;
            int endCount = dataCount * (pageCount + 1);

            var query = await GetAllAsync();

            var movies = query.Skip(startcount).Take(dataCount);

            return  movies.ToList();

        }


        public async Task<Movie> MovieGetById(int movieId)
        {

            var query = await GetAllAsync();
            
            var movie = query.Where(x => x.Id == movieId).FirstOrDefault();

            return movie;
        }

        public async Task<Movie> GetWithMovieRantingsByIdAsync(int movieId)
        {

            var query = await GetAllAsync();

            var movie = query.Include(x => x.MovieRatings).SingleOrDefaultAsync(x => x.Id == movieId);

            return await movie;
        }
    }
}
