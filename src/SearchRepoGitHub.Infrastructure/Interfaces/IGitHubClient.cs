using SearchRepoGitHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Infrastructure.Interfaces
{
    public interface IGitHubClient
    {
        /// <summary>
        /// Busca todos os repositórios disponíveis (sem filtro de query)
        /// </summary>
        /// <returns>Uma lista de repositórios</returns>
        Task<IEnumerable<Repository>> GetAllRepositoriesAsync(IEnumerable<int> favoriteIds);

        /// <summary>
        /// Realiza uma busca de repositórios no GitHub com base na query fornecida
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<Repository>> SearchRepositoriesAsync(string query);
    }
}
