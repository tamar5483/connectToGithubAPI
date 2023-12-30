using Microsoft.Extensions.DependencyInjection;
using PracticodeProject3.Service.Interfaces;
using PracticodeProject3.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticodeProject3.Service
{
    public static class Extensions
        {
            public static void AddGitHubIntegration(this IServiceCollection services, Action<GithubIntegrationOptions> configureOptions)
            {
                services.Configure(configureOptions);
                services.AddScoped<IGitHubService, GitHubService>();
            }
        }
    
}
