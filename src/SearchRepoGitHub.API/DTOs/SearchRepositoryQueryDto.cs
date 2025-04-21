using System.ComponentModel.DataAnnotations;

namespace SearchRepoGitHub.API.DTOs
{
    public class SearchRepositoryQueryDto
    {
        /// <summary>
        /// O termo de busca para filtrar repositórios
        /// </summary>
        [Required(ErrorMessage = "O campo 'query' é obrigatório")]
        [MinLength(3, ErrorMessage = "O termo de busca deve ter pelo menos 3 caracteres")]
        public string Query { get; set; }
    }
}
