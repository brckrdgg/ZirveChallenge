using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualStudio.Services.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using ZirveChallenge.API.Dto;
using ZirveChallenge.Core.Services;

namespace ZirveChallenge.API.Filters
{
    public class NotFoundFilterMovie:ActionFilterAttribute
    {

        private readonly IMovieService _movieService;

        
        public NotFoundFilterMovie(IMovieService movieService)

        {
            _movieService = movieService;
        }


        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

           
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var user = await _movieService.GetByIdAsync(id);

            if (user != null)
            {
                await next();
            }

            else
            {

                ErrorDto error = new ErrorDto();
                error.Status = 404;
                error.Errors.Add("Böyle id de film veritabanında bulunmamaktadır");

                context.Result = new NotFoundObjectResult(error);
            }

        }


    }
}
