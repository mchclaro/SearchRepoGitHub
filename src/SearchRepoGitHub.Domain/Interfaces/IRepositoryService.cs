using SearchRepoGitHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Domain.Interfaces
{
    public interface IRepositoryService
    {
        /// <summary>
        /// Busca repositórios com base em uma query de pesquisa
        /// </summary>
        /// <param name="query">O termo de busca para filtrar repositórios</param>
        /// <returns>Uma lista de repositórios que correspondem a query, ordenados por relevância</returns>
        Task<IEnumerable<IRepositoryDto>> SearchRepositoriesAsync(string query);

        /// <summary>
        /// Alterna o status de favorito de um repositório (marca ou desmarca como favorito)
        /// </summary>
        /// <param name="repositoryId">O ID do repositório que vai ser alterado</param>
        public void ToggleFavorite(int repositoryId);

        /// <summary>
        /// Retorna uma lista de repositórios marcados como favoritos.
        /// </summary>
        /// <returns>Uma lista de repositórios favoritos</returns>
        Task<IEnumerable<IRepositoryDto>> GetFavoriteRepositoriesAsync();
    }
}
