using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ProductHeaderValue = Octokit.ProductHeaderValue;
using PracticodeProject3.Service.Interfaces;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Caching.Memory;

namespace PracticodeProject3.Service.Services
{
    public class GitHubService : IGitHubService
    {
        
        private readonly GitHubClient _client;
        private readonly GithubIntegrationOptions _options;

        public GitHubService(IOptions<GithubIntegrationOptions> options)
        {
            _client = new GitHubClient(new ProductHeaderValue("my-github-app"));
            _options = options.Value;
            _client.Credentials = new Credentials(_options.GithubToken);
        }

        public async Task<IReadOnlyList<Octokit.Repository>> GetPortfolio()
        {
            var rep = await _client.Repository.GetAllForCurrent();
            return rep;
        }

        public async Task<IReadOnlyList<Octokit.Repository>> SearchRepositories(Language? language, string? user, string? repoName)
        {
            //user.UpdatedAt(user.CreatedAt); 
            SearchRepositoriesRequest request;
            if (repoName == null)

                request = new SearchRepositoriesRequest();
            else request = new SearchRepositoriesRequest(repoName);

            if (user != null)
                request.User = user;
            if (null != language)
                request.Language = language;
            var result = await _client.Search.SearchRepo(request);
            return result.Items;
        }

    }

}

