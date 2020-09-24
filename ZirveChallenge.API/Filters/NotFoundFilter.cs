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
    public class NotFoundFilter:ActionFilterAttribute
    {

        private readonly IUserService _userService;

        
        public NotFoundFilter(IUserService userService
)
        {
            _userService = userService;
        }


        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

           
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var user = await _userService.GetByIdAsync(id);

            if (user != null)
            {
                await next();
            }

            else
            {

                ErrorDto error = new ErrorDto();
                error.Status = 404;
                error.Errors.Add("Kullanıcı bilgilerinizi kontrol ediniz");

                context.Result = new NotFoundObjectResult(error);
            }

        }


    }
}
