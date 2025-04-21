using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Domain.Interfaces
{
    public interface IRepositoryDto
    {
        /// <summary>
        /// Identificador do repositorio
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Nome do repositorio
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Contagem das estrelas do repositorio
        /// </summary>
        int Stars { get; set; }

        /// <summary>
        /// Contagem dos forks
        /// </summary>
        int Forks { get; set; }

        /// <summary>
        /// Contagem dos observadores
        /// </summary>
        int Watchers { get; set; }

        /// <summary>
        /// Indica se foi salvo como favorito
        /// </summary>
        bool IsFavorite { get; set; }
    }
}
