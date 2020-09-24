using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZirveChallenge.API.Dto;
using ZirveChallenge.Core.Entities;

namespace ZirveChallenge.API.Mapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {        
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<MovieRating, MovieRatingDto>();
            CreateMap<MovieRatingDto, MovieRating>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
           
        }

    }
}
