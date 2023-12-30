using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticodeProject3.Service.Interfaces
{
    public interface IGitHubService
    {
        public Task<IReadOnlyList<Octokit.Repository>> GetPortfolio();
        public Task<IReadOnlyList<Octokit.Repository>> SearchRepositories(Language? language, string? user, string? repoName);



        //public Task<int> GetUserFollowersAsync(string userName);

        //public Task<List<Repository>> SearchRepositoriesInCSharp(string userName);

    }

}
