using Microsoft.AspNetCore.Mvc;
using SearchRepoGitHub.API.DTOs;
using SearchRepoGitHub.Domain.Interfaces;
using SearchRepoGitHub.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace SearchRepoGitHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoriesController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public RepositoriesController(IRepositoryService repositoryService) => _repositoryService = repositoryService;

        /// <summary>
        /// Busca repositórios com base em uma query de pesquisa
        /// </summary>
        /// <param name="queryDto">O DTO contendo o termo de busca</param>
        /// <returns>Uma lista de repositórios correspondentes a query</returns>
        [HttpGet]
        public async Task<IActionResult> SearchRepositories([FromQuery] SearchRepositoryQueryDto queryDto)
        {
            // Validação automática: Se falhar, lança ValidationException
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(ModelState.Values.First().Errors.First().ErrorMessage);
            }

            var repositories = await _repositoryService.SearchRepositoriesAsync(queryDto.Query);
            return Ok(repositories);
        }

        /// <summary>
        /// Alterna o status de favorito de um repositório
        /// </summary>
        /// <param name="repositoryId">O ID do repositório</param>
        /// <returns>Resposta sem conteúdo</returns>
        [HttpPost("{repositoryId}/favorite")]
        public IActionResult ToggleFavorite(
            [Range(1, int.MaxValue, ErrorMessage = "O ID do repositório deve ser um número positivo.")]
        int repositoryId)
        {
            // Validação automática: Se falhar, lança ValidationException
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(ModelState.Values.First().Errors.First().ErrorMessage);
            }

            _repositoryService.ToggleFavorite(repositoryId);
            return NoContent();
        }

        /// <summary>
        /// Retorna uma lista de repositórios marcados como favoritos
        /// </summary>
        /// <returns>Uma lista de repositórios favoritos</returns>
        [HttpGet("favorites")]
        public async Task<IActionResult> GetFavoriteRepositories()
        {
            var favorites = await _repositoryService.GetFavoriteRepositoriesAsync();
            return Ok(favorites);
        }
    }
}
