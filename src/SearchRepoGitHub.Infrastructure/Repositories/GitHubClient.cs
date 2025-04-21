using SearchRepoGitHub.Domain.Entities;
using SearchRepoGitHub.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Infrastructure.Repositories
{
    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient _httpClient;

        public GitHubClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("https://api.github.com/");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "SearchRepoGitHub");
        }

        /// <summary>
        /// Busca repositórios favoritos individualmente com base em seus IDs.
        /// </summary>
        /// <param name="favoriteIds">Lista de IDs dos repositórios favoritos.</param>
        /// <returns>Uma lista de repositórios correspondentes aos IDs fornecidos.</returns>
        public async Task<IEnumerable<Repository>> GetAllRepositoriesAsync(IEnumerable<int> favoriteIds)
        {
            List<Repository> repositories = new();

            foreach (var id in favoriteIds)
            {
                try
                {
                    // Busca o repositório pelo ID específico
                    var repository = await _httpClient.GetFromJsonAsync<Repository>($"repositories/{id}");
                    if (repository != null)
                    {
                        repositories.Add(repository);
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Loga o erro caso o repositório não seja encontrado ou ocorra outro problema
                    Console.WriteLine($"Erro ao buscar repositório com ID {id}: {ex.Message}");
                }
            }

            return repositories;
        }


        /// <summary>
        /// Realiza uma busca de repositórios no GitHub com base na query fornecida
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Repository>> SearchRepositoriesAsync(string query)
        {
            string finalQuery = string.IsNullOrWhiteSpace(query) ? "dotnet" : query;
            var response = await _httpClient.GetFromJsonAsync<GitHubResponse>($"search/repositories?q={finalQuery}");
            return response?.Items ?? new List<Repository>();
        }
    }

    /// <summary>
    /// Classe de resposta da API do GitHub
    /// </summary>
    internal class GitHubResponse
    {
        public List<Repository> Items { get; set; }
    }
}
