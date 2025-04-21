## Teste técnico - Entrevista Dev. Backend

### Descrição do Projeto
### Você deverá desenvolver uma aplicação web que permita:
### •	Buscar repositórios públicos do GitHub utilizando o nome (ou parte do nome) do repositório como filtro;
### •	Marcar repositórios como favoritos durante a execução da aplicação;
### •	Exibir uma lista de repositórios ordenada por relevância, conforme lógica de negócio definida por você.


## Funcionalidades Obrigatórias
### Buscar repositórios públicos por nomehttps://github.com/mchclaro/SearchRepoGitHub/blob/master/README.md
### Deve ser possível pesquisar por qualquer repositório público no GitHub.
### A chamada à API do GitHub deve ser implementada por você. o	API aberta: https://api.github.com

## Marcar repositórios como favoritos
### Deve existir uma funcionalidade para favoritar/desfavoritar repositórios.
### Os favoritos devem ser mantidos em tempo de execução, sem persistência em banco de dados.
## Listar repositórios por relevância
### Crie um endpoint que retorne os repositórios ordenados por relevância.
### Você deverá definir a lógica de cálculo da relevância com base em dados como:
#### Estrelas (stargazers_count)
#### Forks (forks_count)
#### Watchers (watchers_count)
### Explique sua escolha de lógica via comentários no código.


## O que foi feito no projeto

### Endpoint que faz a busca por repositórios públicos no GitHub: /api/repositories/search?query={nomeDoRepo}
### Endpoint que adiciona e remove repositórios dos favoritos salvo em tempo de execução (/api/Repositories/{repositoryId}/favorite)
### Endpoint que retorna a lista de repositórios favoritos (/api/Repositories/favorites)

### Existe um método que chama CalculateRelevance no qual ele calcula a relevancia dos repositórios seguindo a lógica: estrelas (50%), forks (30%), watchers (20%)

### Frontend em Angular bem simples
### Um campo pra digitar a query de busca e um button pra Buscar
### Vai aparecer uma lista com os repositórios e em cada um deles tem um button pra marcar como favorito
### Depois você pode alternar para Favoritos e ver a lista somente dos repositórios salvos como favorito
### Tanto no Buscar Repositórios como no Favoritos, é possível Desmacar o repositório como favorito.
