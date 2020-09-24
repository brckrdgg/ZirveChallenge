using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZirveChallenge.API.Dto;
using ZirveChallenge.API.Filters;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Helpers;
using ZirveChallenge.Core.Services;

namespace ZirveChallenge.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieRatingController : ControllerBase
    {
        private readonly IService<MovieRating> _movieRatingService;
        private readonly IMapper _mapper;
        

        public MovieRatingController(IService<MovieRating> movieRatingService, IMapper mapper)
        {

            _movieRatingService = movieRatingService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movieRatings = await _movieRatingService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MovieRatingDto>>(movieRatings));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movieRatings = await _movieRatingService.GetByIdAsync(id);
            return Ok(_mapper.Map<MovieRatingDto>(movieRatings));
        }



        /// <summary>
        /// Filme not ve puan Ekleme
        /// </summary>
        /// <param name="movieRatingDto"></param>
        /// <returns></returns>
        [ValidationFilter]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(MovieRatingDto movieRatingDto)
        {
            movieRatingDto.UserId = ActiveUser.Get().UserId;
            var newMovieRating = await _movieRatingService.Insert(_mapper.Map<MovieRating>(movieRatingDto));
            return Created(string.Empty, _mapper.Map<MovieRatingDto>(newMovieRating));
        }

        [HttpPut]
        public IActionResult Update(MovieRatingDto movieRatingDto)
        {
            var movieRating = _movieRatingService.Update(_mapper.Map<MovieRating>(movieRatingDto));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movieRating = _movieRatingService.GetByIdAsync(id).Result;
            _movieRatingService.Remove(movieRating);
            return NoContent();
        }


    }
}
