using SearchRepoGitHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Infrastructure.Data
{
    public class InMemoryFavoriteRepository : IFavoriteRepository
    {
        private readonly HashSet<int> _favorites = new();

        /// <summary>
        /// Adiciona um repositório na lista de favoritos
        /// </summary>
        /// <param name="repositoryId">O ID do repositório que vai ser adicionado</param>
        public void AddFavorite(int repositoryId)
        {
            _favorites.Add(repositoryId);
        }

        /// <summary>
        /// Remove um repositório da lista de favoritos
        /// </summary>
        /// <param name="repositoryId">O ID do repositório que vai ser removido</param>
        public void RemoveFavorite(int repositoryId)
        {
            _favorites.Remove(repositoryId);
        }

        /// <summary>
        /// Verifica se um repositório ta marcado como favorito
        /// </summary>
        /// <param name="repositoryId">O ID do repositório que vai ser verificado</param>
        /// <returns></returns>
        public bool IsFavorite(int repositoryId)
        {
            return _favorites.Contains(repositoryId);
        }

        /// <summary>
        /// Retorna uma lista de IDs dos repositórios favoritos
        /// </summary>
        /// <returns>Uma lista de IDs dos repositórios favoritos</returns>
        public IEnumerable<int> GetFavorites()
        {
            return _favorites.ToList();
        }
    }
}
