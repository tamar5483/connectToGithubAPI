using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Octokit;
using PracticodeProject3.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;


namespace PracticodeProject3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly  IGitHubService _gitHubService;
        private IMemoryCache _cache;
        private ILogger<GitHubController> _logger;

        public GitHubController(IGitHubService gitHubService, IMemoryCache cache, ILogger<GitHubController> logger)
        {
            _gitHubService = gitHubService;
            _cache = cache;
            _logger = logger;
        }

        // GET: api/<RolesController>
        [HttpGet("portfolio")]
        public async Task<IReadOnlyList<Octokit.Repository>> Get()
        {
            if (_cache.TryGetValue("portfolio", out IReadOnlyList<Octokit.Repository>repos ))
                return repos;
            var option = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                .SetSlidingExpiration(TimeSpan.FromSeconds(10));
            repos = await _gitHubService.GetPortfolio();
            _cache.Set("portfolio", repos, option);
            //_cache.GetAge("UserPrortfolio");
            return repos;


        }
        [HttpGet("search")]

        public async Task<IReadOnlyList<Octokit.Repository>> Search(Language? language, string? user, string? repoName)
        {
            return await _gitHubService.SearchRepositories(language, user, repoName);
        }
      }
}
