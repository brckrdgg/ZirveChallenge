using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Repositories;
using ZirveChallenge.Core.Services;
using ZirveChallenge.Data.Repositories;
using ZirveChallenge.Services.Services;
using static ZirveChallenge.Core.Entities.APIMovie;

namespace ZirveChallenge.Core.Helpers.Test
{
    public class GetMovieByAPIJob : IJob
    {
    
        private readonly IServiceProvider _serviceProvider;

        public GetMovieByAPIJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;        
        }

        public  Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var contextt = scope.ServiceProvider.GetRequiredService<IMovieService>();
                 contextt.GetAllMovieByAPI();
            };
            
            return Task.CompletedTask;
        }
    }
}