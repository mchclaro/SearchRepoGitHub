using SearchRepoGitHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Application.DTOs
{
    public class RepositoryDto : IRepositoryDto
    {
        /// <summary>
        /// Id do repositorio
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do repositorio
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contagem das estrelas do repositorio
        /// </summary>
        public int Stars { get; set; }

        /// <summary>
        /// Contagem dos forks
        /// </summary>
        public int Forks { get; set; }

        /// <summary>
        /// Contagem dos observadores
        /// </summary>
        public int Watchers { get; set; }

        /// <summary>
        /// Indica se foi salvo como favorito
        /// </summary>
        public bool IsFavorite { get; set; }
    }
}
