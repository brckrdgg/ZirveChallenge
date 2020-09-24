using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using Newtonsoft.Json;
using ZirveChallenge.API.Dto;
using ZirveChallenge.API.Filters;
using ZirveChallenge.Core.Dto;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Services;

namespace ZirveChallenge.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
        }

        [ServiceFilter(typeof(NotFoundFilterMovie))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);

            return Ok(_mapper.Map<MovieDto>(movie));
        }



        [HttpPost]
        public async Task<IActionResult> Save(MovieDto movieDto)
        {

            var newMovie = await _movieService.Insert(_mapper.Map<Movie>(movieDto));
            return Created(string.Empty, _mapper.Map<MovieDto>(newMovie));
        }

        [HttpPut]
        public IActionResult Update(MovieDto movieDto)
        {

            var movie = _movieService.Update(_mapper.Map<Movie>(movieDto));
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetByIdAsync(id).Result;
            _movieService.Remove(movie);
            return NoContent();
        }


        /// <summary>
        /// www.themoviedb.org adresinden çekilen filmleri Ekleme
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetAllMovieByAPI()
        {
            _movieService.GetAllMovieByAPI();
            return Ok();
        }

        /// <summary>
        /// Sayfa Numarasına göre Film Listesi Getirme
        /// </summary>
        /// <param name="pageCount"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetMovieByPageNumber([FromBody] int pageCount)
        {
            var movies =  _movieService.GetMovieByPageNumber(pageCount);
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
        }


        /// <summary>
        /// Seçilen Filmi Email olarak Gönderme
        /// </summary>
        /// <param name="movieSendDto"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> MovieSendMail(MovieSendDto movieSendDto)
        {
           await _movieService.MovieSendMail(movieSendDto);

            return Ok("Mail Gönderilmiştir");
        }


        /// <summary>
        /// Seçilen filme göre kullanıcının filme verdiği puanları, ortalama puanı ,film bilgisini Getirme
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [Authorize]
       // [ServiceFilter(typeof(NotFoundFilterMovie))]
        [HttpPost]
        public async Task<IActionResult> GetWithMovieRantingsByIdAsync( int movieId)
        {
            MovieWithMovieRatingDto movieWithMovieRatingDto = new MovieWithMovieRatingDto();
            movieWithMovieRatingDto= await _movieService.GetWithMovieRantings(movieId);
            
            return Ok(movieWithMovieRatingDto);
        }

    }
}

