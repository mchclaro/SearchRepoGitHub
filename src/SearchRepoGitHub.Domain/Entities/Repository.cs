using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Domain.Entities
{
    public class Repository
    {
        /// <summary>
        /// Identificador do repositorio
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

        /// <summary>
        /// Calcula a relevância do repositório com base em estrelas, forks e watchers
        /// </summary>
        /// <returns>Valor de relevância calculado</returns>
        public double CalculateRelevance()
        {
            // Lógica de relevância: estrelas (50%), forks (30%), watchers (20%)
            return (Stars * 0.5) + (Forks * 0.3) + (Watchers * 0.2);
        }
    }
}
