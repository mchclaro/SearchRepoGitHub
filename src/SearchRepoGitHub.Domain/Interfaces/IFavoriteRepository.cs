using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Domain.Interfaces
{
    public interface IFavoriteRepository
    {
        /// <summary>
        /// Adiciona um repositório na lista de favoritos
        /// </summary>
        /// <param name="repositoryId">O ID do repositório que vai ser adicionado</param>
        public void AddFavorite(int repositoryId);

        /// <summary>
        /// Remove um repositório da lista de favoritos
        /// </summary>
        /// <param name="repositoryId">O ID do repositório que vai ser removido</param>
        public void RemoveFavorite(int repositoryId);

        /// <summary>
        /// Verifica se um repositório ta marcado como favorito
        /// </summary>
        /// <param name="repositoryId">O ID do repositório que vai ser verificado</param>
        /// <returns>True se o repositório estiver na lista de favoritos, caso não, false</returns>
        public bool IsFavorite(int repositoryId);

        /// <summary>
        /// Retorna uma lista de IDs dos repositórios favoritos
        /// </summary>
        /// <returns>Uma lista de IDs dos repositórios favoritos</returns>
        public IEnumerable<int> GetFavorites();
    }
}
